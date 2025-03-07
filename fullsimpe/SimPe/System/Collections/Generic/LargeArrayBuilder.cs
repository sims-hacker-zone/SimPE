// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
	/// <summary>
	/// Represents a position within a <see cref="LargeArrayBuilder2{T}"/>.
	/// </summary>
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	internal readonly struct CopyPosition
	{
		/// <summary>
		/// Constructs a new <see cref="CopyPosition"/>.
		/// </summary>
		/// <param name="row">The index of the buffer to select.</param>
		/// <param name="column">The index within the buffer to select.</param>
		internal CopyPosition(int row, int column)
		{
			Debug.Assert(row >= 0);
			Debug.Assert(column >= 0);

			Row = row;
			Column = column;
		}

		/// <summary>
		/// Represents a position at the start of a <see cref="LargeArrayBuilder2{T}"/>.
		/// </summary>
		public static CopyPosition Start => default;

		/// <summary>
		/// The index of the buffer to select.
		/// </summary>
		internal int Row
		{
			get;
		}

		/// <summary>
		/// The index within the buffer to select.
		/// </summary>
		internal int Column
		{
			get;
		}

		/// <summary>
		/// If this position is at the end of the current buffer, returns the position
		/// at the start of the next buffer. Otherwise, returns this position.
		/// </summary>
		/// <param name="endColumn">The length of the current buffer.</param>
		public CopyPosition Normalize(int endColumn)
		{
			Debug.Assert(Column <= endColumn);

			return Column == endColumn ?
				new CopyPosition(Row + 1, 0) :
				this;
		}

		/// <summary>
		/// Gets a string suitable for display in the debugger.
		/// </summary>
		private string DebuggerDisplay => $"[{Row}, {Column}]";
	}

	/// <summary>
	/// Helper type for building dynamically-sized arrays while minimizing allocations and copying.
	/// </summary>
	/// <typeparam name="T">The element type.</typeparam>
	internal struct LargeArrayBuilder2<T>
	{
		private const int StartingCapacity = 4;
		private const int ResizeLimit = 8;

		private readonly int _maxCapacity;  // The maximum capacity this builder can have.
		private T[] _first;                 // The first buffer we store items in. Resized until ResizeLimit.
		private ArrayBuilder2<T[]> _buffers; // After ResizeLimit * 2, we store previous buffers we've filled out here.
		private T[] _current;               // Current buffer we're reading into. If _count <= ResizeLimit, this is _first.
		private int _index;                 // Index into the current buffer.

		/// <summary>
		/// Constructs a new builder.
		/// </summary>
		/// <param name="initialize">Pass <c>true</c>.</param>
		public LargeArrayBuilder2(bool initialize)
			: this(maxCapacity: int.MaxValue)
		{
			// This is a workaround for C# not having parameterless struct constructors yet.
			// Once it gets them, replace this with a parameterless constructor.
			Debug.Assert(initialize);
		}

		/// <summary>
		/// Constructs a new builder with the specified maximum capacity.
		/// </summary>
		/// <param name="maxCapacity">The maximum capacity this builder can have.</param>
		/// <remarks>
		/// Do not add more than <paramref name="maxCapacity"/> items to this builder.
		/// </remarks>
		public LargeArrayBuilder2(int maxCapacity)
			: this()
		{
			Debug.Assert(maxCapacity >= 0);

			_first = _current = Array.Empty<T>();
			_maxCapacity = maxCapacity;
		}

		/// <summary>
		/// Gets the number of items added to the builder.
		/// </summary>
		public int Count
		{
			get; private set;
		}

		/// <summary>
		/// Adds an item to this builder.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <remarks>
		/// Use <see cref="Add"/> if adding to the builder is a bottleneck for your use case.
		/// Otherwise, use <see cref="SlowAdd"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(T item)
		{
			Debug.Assert(_maxCapacity > Count);

			int index = _index;
			T[] current = _current;

			// Must be >= and not == to enable range check elimination
			if ((uint)index >= (uint)current.Length)
			{
				AddWithBufferAllocation(item);
			}
			else
			{
				current[index] = item;
				_index = index + 1;
			}

			Count++;
		}

		// Non-inline to improve code quality as uncommon path
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddWithBufferAllocation(T item)
		{
			AllocateBuffer();
			_current[_index++] = item;
		}

		/// <summary>
		/// Adds a range of items to this builder.
		/// </summary>
		/// <param name="items">The sequence to add.</param>
		/// <remarks>
		/// It is the caller's responsibility to ensure that adding <paramref name="items"/>
		/// does not cause the builder to exceed its maximum capacity.
		/// </remarks>
		public void AddRange(IEnumerable<T> items)
		{
			Debug.Assert(items != null);

			using (IEnumerator<T> enumerator = items.GetEnumerator())
			{
				T[] destination = _current;
				int index = _index;

				// Continuously read in items from the enumerator, updating _count
				// and _index when we run out of space.

				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;

					if ((uint)index >= (uint)destination.Length)
					{
						AddWithBufferAllocation(item, ref destination, ref index);
					}
					else
					{
						destination[index] = item;
					}

					index++;
				}

				// Final update to _count and _index.
				Count += index - _index;
				_index = index;
			}
		}

		// Non-inline to improve code quality as uncommon path
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddWithBufferAllocation(T item, ref T[] destination, ref int index)
		{
			Count += index - _index;
			_index = index;
			AllocateBuffer();
			destination = _current;
			index = _index;
			_current[index] = item;
		}

		/// <summary>
		/// Copies the contents of this builder to the specified array.
		/// </summary>
		/// <param name="array">The destination array.</param>
		/// <param name="arrayIndex">The index in <see cref="array"/> to start copying to.</param>
		/// <param name="count">The number of items to copy.</param>
		public void CopyTo(T[] array, int arrayIndex, int count)
		{
			Debug.Assert(arrayIndex >= 0);
			Debug.Assert(count >= 0 && count <= Count);
			Debug.Assert(array?.Length - arrayIndex >= count);

			for (int i = 0; count > 0; i++)
			{
				// Find the buffer we're copying from.
				T[] buffer = GetBuffer(index: i);

				// Copy until we satisfy count, or we reach the end of the buffer.
				int toCopy = Math.Min(count, buffer.Length);
				Array.Copy(buffer, 0, array, arrayIndex, toCopy);

				// Increment variables to that position.
				count -= toCopy;
				arrayIndex += toCopy;
			}
		}

		/// <summary>
		/// Copies the contents of this builder to the specified array.
		/// </summary>
		/// <param name="position">The position in this builder to start copying from.</param>
		/// <param name="array">The destination array.</param>
		/// <param name="arrayIndex">The index in <see cref="array"/> to start copying to.</param>
		/// <param name="count">The number of items to copy.</param>
		/// <returns>The position in this builder that was copied up to.</returns>
		public CopyPosition CopyTo(CopyPosition position, T[] array, int arrayIndex, int count)
		{
			Debug.Assert(array != null);
			Debug.Assert(arrayIndex >= 0);
			Debug.Assert(count > 0 && count <= Count);
			Debug.Assert(array.Length - arrayIndex >= count);

			// Go through each buffer, which contains one 'row' of items.
			// The index in each buffer is referred to as the 'column'.

			/*
             * Visual representation:
             *
             *       C0   C1   C2 ..  C31 ..   C63
             * R0:  [0]  [1]  [2] .. [31]
             * R1: [32] [33] [34] .. [63]
             * R2: [64] [65] [66] .. [95] .. [127]
             */

			int row = position.Row;
			int column = position.Column;

			T[] buffer = GetBuffer(row);
			int copied =
#if __MonoCS__
            CopyToCore(buffer, column, array, ref arrayIndex, ref count);
#else
			CopyToCore(buffer, column);
#endif

			if (count == 0)
			{
				return new CopyPosition(row, column + copied).Normalize(buffer.Length);
			}

			do
			{
				buffer = GetBuffer(++row);
				copied =
#if __MonoCS__
                CopyToCore(buffer, 0, array, ref arrayIndex, ref count);
#else
				CopyToCore(buffer, 0);
#endif
			} while (count > 0);

			return new CopyPosition(row, copied).Normalize(buffer.Length);

#if __MonoCS__
        }

        static int CopyToCore(T[] sourceBuffer, int sourceIndex, T[] array, ref int arrayIndex, ref int count)
#else
			int CopyToCore(T[] sourceBuffer, int sourceIndex)
#endif
			{
				Debug.Assert(sourceBuffer.Length > sourceIndex);

				// Copy until we satisfy `count` or reach the end of the current buffer.
				int copyCount = Math.Min(sourceBuffer.Length - sourceIndex, count);
				Array.Copy(sourceBuffer, sourceIndex, array, arrayIndex, copyCount);

				arrayIndex += copyCount;
				count -= copyCount;

				return copyCount;
			}

#if !__MonoCS__
		}
#endif

		/// <summary>
		/// Retrieves the buffer at the specified index.
		/// </summary>
		/// <param name="index">The index of the buffer.</param>
		public T[] GetBuffer(int index)
		{
			Debug.Assert(index >= 0 && index < _buffers.Count + 2);

			return index == 0 ? _first :
				index <= _buffers.Count ? _buffers[index - 1] :
				_current;
		}

		/// <summary>
		/// Adds an item to this builder.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <remarks>
		/// Use <see cref="Add"/> if adding to the builder is a bottleneck for your use case.
		/// Otherwise, use <see cref="SlowAdd"/>.
		/// </remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SlowAdd(T item) => Add(item);

		/// <summary>
		/// Creates an array from the contents of this builder.
		/// </summary>
		public T[] ToArray()
		{
			if (TryMove(out T[] array))
			{
				// No resizing to do.
				return array;
			}

			array = new T[Count];
			CopyTo(array, 0, Count);
			return array;
		}

		/// <summary>
		/// Attempts to transfer this builder into an array without copying.
		/// </summary>
		/// <param name="array">The transferred array, if the operation succeeded.</param>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		public bool TryMove(out T[] array)
		{
			array = _first;
			return Count == _first.Length;
		}

		private void AllocateBuffer()
		{
			// - On the first few adds, simply resize _first.
			// - When we pass ResizeLimit, allocate ResizeLimit elements for _current
			//   and start reading into _current. Set _index to 0.
			// - When _current runs out of space, add it to _buffers and repeat the
			//   above step, except with _current.Length * 2.
			// - Make sure we never pass _maxCapacity in all of the above steps.

			Debug.Assert((uint)_maxCapacity > (uint)Count);
			Debug.Assert(_index == _current.Length, $"{nameof(AllocateBuffer)} was called, but there's more space.");

			// If _count is int.MinValue, we want to go down the other path which will raise an exception.
			if ((uint)Count < ResizeLimit)
			{
				// We haven't passed ResizeLimit. Resize _first, copying over the previous items.
				Debug.Assert(_current == _first && Count == _first.Length);

				int nextCapacity = Math.Min(Count == 0 ? StartingCapacity : Count * 2, _maxCapacity);

				_current = new T[nextCapacity];
				Array.Copy(_first, 0, _current, 0, Count);
				_first = _current;
			}
			else
			{
				Debug.Assert(_maxCapacity > ResizeLimit);
				Debug.Assert(Count == ResizeLimit ^ _current != _first);

				int nextCapacity;
				if (Count == ResizeLimit)
				{
					nextCapacity = ResizeLimit;
				}
				else
				{
					// Example scenario: Let's say _count == 64.
					// Then our buffers look like this: | 8 | 8 | 16 | 32 |
					// As you can see, our count will be just double the last buffer.
					// Now, say _maxCapacity is 100. We will find the right amount to allocate by
					// doing min(64, 100 - 64). The lhs represents double the last buffer,
					// the rhs the limit minus the amount we've already allocated.

					Debug.Assert(Count >= ResizeLimit * 2);
					Debug.Assert(Count == _current.Length * 2);

					_buffers.Add(_current);
					nextCapacity = Math.Min(Count, _maxCapacity - Count);
				}

				_current = new T[nextCapacity];
				_index = 0;
			}
		}
	}
}

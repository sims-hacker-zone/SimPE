// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;

namespace System.Collections.Generic
{
	internal sealed class StackDebugView2<T>
	{
		private readonly Stack2<T> _stack;

		public StackDebugView2(Stack2<T> stack)
		{
			if (stack == null)
			{
				throw new ArgumentNullException(nameof(stack));
			}

			_stack = stack;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				return _stack.ToArray();
			}
		}
	}
}

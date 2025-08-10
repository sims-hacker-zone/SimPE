// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimPe.Common.Extensions;

public class DictionaryTKeyEnumTValueConverter : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeToConvert.IsGenericType
		       && typeToConvert.GetGenericTypeDefinition() == typeof(EnumDisplayNameItem<>)
		       && typeToConvert.GetGenericArguments()[0].IsEnum;
	}

	public override JsonConverter CreateConverter(
		Type type,
		JsonSerializerOptions options)
	{
		Type[] typeArguments = type.GetGenericArguments();
		Type enumType = typeArguments[0];


		return (JsonConverter)Activator.CreateInstance(
			typeof(EnumConverterInner<>).MakeGenericType(
				[enumType]),
			BindingFlags.Instance | BindingFlags.Public,
			binder: null,
			args: [options],
			culture: null)!;
	}

	private class EnumConverterInner<T>(JsonSerializerOptions options) :
		JsonConverter<EnumDisplayNameItem<T>> where T : struct, Enum
	{
		private readonly JsonConverter<T> valueConverter = (JsonConverter<T>)options
			.GetConverter(typeof(T));

		private readonly Type valueType = typeof(T);

		public override EnumDisplayNameItem<T> Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			T value = valueConverter.Read(ref reader, valueType, options);

			return new(value);
		}

		public override void Write(
			Utf8JsonWriter writer,
			EnumDisplayNameItem<T> item,
			JsonSerializerOptions options)
		{
			valueConverter.Write(writer, item.Item, options);
		}
	}
}

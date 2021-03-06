﻿namespace Web.Code.Common.Extensions
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// Converts the given object to JSON format
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToJSON(this object obj)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
			return json;
		}

		/// <summary>
		/// Deserializes this string back into our response object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonFormattedString"></param>
		/// <returns></returns>
		public static T FromJSON<T>(this string jsonFormattedString)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonFormattedString);
		}
		
	}
}

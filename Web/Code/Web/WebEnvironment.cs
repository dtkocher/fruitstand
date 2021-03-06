﻿using System.Web;

namespace Web.Code.Web
{
	public class WebEnvironment
	{
		public string ApplicationPath
		{
			get
			{
				if (HttpContext.Current == null) return "";
				string appPath = HttpContext.Current.Request.ApplicationPath ?? "";
				return appPath;
			}
		}

		public bool IsSecureConnection
		{
			get { return HttpContext.Current.Request.IsSecureConnection; }
		}

		public virtual string Domain
		{
			get
			{
				string s = HttpContext.Current.Request.ServerVariables["SERVER_NAME"] ?? "";

				// Strip trailing guff
				if (s.EndsWith("/")) s = s.Substring(0, s.Length - 1);

				return s;
			}
		}
		
		public virtual string SiteRoot
		{
			get
			{
				if (HttpContext.Current == null) return "";
				string s = "//" + Domain;

				// Add port
				if (HttpContext.Current.Request.Url.Port != 80) s += ":" + HttpContext.Current.Request.Url.Port;

				if (!s.EndsWith("/"))
				{
					s += "/";
				}

				// Ensure ends with slash
				string appPath = ApplicationPath;
				if (!appPath.EndsWith("/"))
				{
					appPath += "/";
				}
				if (appPath == "" || appPath == "/")
				{
					return s;
				}
				if (appPath.StartsWith("/"))
				{
					appPath = appPath.Substring(1);
				}
				s += appPath;
				if (!s.EndsWith("/"))
				{
					s += "/";
				}

				return s.ToLower();
			}
		}

		public string MapPath(string url)
		{
			if (HttpContext.Current == null) return "";
			return HttpContext.Current.Server.MapPath(url);
		}

		/// <summary>
		///     Returns the path to the full website
		/// </summary>
		/// <param name="partUrl"></param>
		/// <returns></returns>
		public string GetFullUrl(string partUrl, bool ensureHttpPrefix = false)
		{
			if (partUrl.ToLower().StartsWith("http") || partUrl.ToLower().StartsWith("//"))
			{
				return partUrl;
			}
			if (partUrl.StartsWith("~"))
			{
				partUrl = partUrl.Substring(1);
			}
			if (partUrl.StartsWith("/"))
			{
				partUrl = partUrl.Substring(1);
			}

			string result = SiteRoot + partUrl;

			// Full URL prefix (required if URL used on another site)
			if (ensureHttpPrefix && !result.ToLower().StartsWith("http")) result = "http:" + result;
			return result;
		}
	}
}
﻿using System;
using System.Collections.Generic;

namespace Web.Code.Contracts.Entities.ApiModels
{
	public class ErrorResponse
	{
		public string Message { get; set; }
		public Dictionary<string, string[]> ValidationFailures { get; set; }
		public Guid? Id { get; set; }
		public ErrorResultCode ResultCode { get; set; }
	}
}
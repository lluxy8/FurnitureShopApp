﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
    }
    public class Result<T> : IResult
    {
        public bool IsSuccess { get; }
        public string? Message { get; }
        public T? Data { get; }

        private Result(T data)
        {
            IsSuccess = true;
            Data = data;
            Message = null;
        }

        private Result(string message)
        {
            IsSuccess = false;
            Message = message;
            Data = default;
        }

        public static Result<T> Success(T data)
            => new(data);

        public static Result<T> Failure(string message)
            => new(message);
    }
}

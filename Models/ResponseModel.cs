﻿namespace TodoTask.Web.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public T Data { get; set; }
    }
}

﻿namespace WebAPI.Endpoints.AccountEndpoints
{
    public class ListAccountsRequest
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;

    }
}
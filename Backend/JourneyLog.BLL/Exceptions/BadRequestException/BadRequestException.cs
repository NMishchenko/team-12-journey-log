﻿namespace JourneyLog.BLL.Exceptions.BadRequestException;

public class BadRequestException: Exception
{
    public BadRequestException(string message): base(message){}
}
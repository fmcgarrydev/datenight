﻿namespace DateNight.Core.Entities;

public class BaseEntity<T>
{
    public T? Id { get; protected set; }
}
﻿using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction;

public class TransactionScopeAspect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using TransactionScope transactionScope = new();
        try
        {
            invocation.Proceed();
            transactionScope.Complete();
        }
        catch
        {
            transactionScope.Dispose();
            throw;
        }
    }
}
﻿using System;
using CosteffectiveCode.Common;
using CostEffectiveCode.Domain.Ddd.Entities;
using CostEffectiveCode.Domain.Ddd.UnitOfWork;
using JetBrains.Annotations;

namespace CostEffectiveCode.Domain.Cqrs.Commands
{
    public class DeleteEntityCommand<T> : CommandBase<T>
        where T: class, IEntity
    {
        private readonly IScope<IUnitOfWork> _unitOfWorkScope;

        public DeleteEntityCommand([NotNull] IScope<IUnitOfWork> unitOfWorkScope)
        {
            if (unitOfWorkScope == null) throw new ArgumentNullException(nameof(unitOfWorkScope));
            _unitOfWorkScope = unitOfWorkScope;
        }

        protected override void DoExecute(T context)
        {
            _unitOfWorkScope.Instance.Delete(context);
            _unitOfWorkScope.Instance.Commit();
        }
    }
}

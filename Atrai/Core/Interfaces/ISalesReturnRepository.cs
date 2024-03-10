﻿using Atrai.Core.Entity;
using Atrai.Core.Interfaces.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Core.Interfaces
{
    public interface ISalesReturnRepository : IBaseRepository<SalesReturnModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }



    public interface ISalesReturnPaymentRepository : IBaseRepository<SalesReturnPaymentModel>
    {
    }

    public interface ISalesReturnItemsRepository : IBaseRepository<SalesReturnItemsModel>
    {
    }
    public interface ISalesReturnBatchItemsRepository : IBaseRepository<SalesReturnBatchItemsModel>
    {
    }

    public interface ISalesExchangeItemsRepository : IBaseRepository<SalesExchangeItemsModel>
    {
    }
    public interface ISalesExchangeBatchItemsRepository : IBaseRepository<SalesExchangeBatchItemsModel>
    {
    }
}
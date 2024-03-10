using Atrai.Core.Entity;
using Atrai.Core.Interfaces.Base;
using Atrai.Core.Interfaces.Self;
using Atrai.Core.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrai.Core.Interfaces
{
    public interface ISaleRepository : IBaseRepository<SalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllForDropDownForCustomer(bool isComId = true , int CustomerId=0);
        Task<List<InvoiceReportViewModel>> InvoiceList(DateTime startdt,DateTime endDt); 
    }

    public interface ISalesTagRepository : IBaseRepository<SalesTagModel>
    {
    }
    public interface IRecurringDetailsRepository : IBaseRepository<RecurringDetailsModel>
    {
    }
    public interface ISalesProductTaxRepository : IBaseRepository<SalesProductTaxModel>
    {
    }  
    public interface IFeedbackRepository : IBaseRepository<FeedbackModel>
    {
    }

    public interface ISalesItemsRepository : IBaseRepository<SalesItemsModel>
    {
    }
    public interface IAgencyRepository : IBaseRepository<AgencyModel>
    {
    }
    public interface ISalesTaxRepository : IBaseRepository<SalesTaxModel>
    {
    }
    public interface IAdvanceTrasactionTrackingRepository : IBaseRepository<AdvanceTrasactionTrackingModel>
    {
    }
    public interface IMasterSalesTaxRepository : IBaseRepository<MasterSalesTaxModel>
    {
        IEnumerable<SelectListItem> GetAllSalesTaxForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllPurchaseTaxForDropDown(bool isComId = true);
    }

    //public interface IMasterSalesTaxRepository : IBaseRepository<MasterSalesTaxModel>
    //{
    //}

    public interface ISalesPaymentRepository : IBaseRepository<SalesPaymentModel>
    {
    }

    public interface ISalesTermsRepository : IBaseRepository<SalesTermsModel>
    {
    }


    public interface ISalesBatchItemsRepository : IBaseRepository<SalesBatchItemsModel>
    {
    }


    public interface ITermsMainRepository : IBaseRepository<TermsMainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

        IEnumerable<SelectListItem> GetSalesTermsList(bool isComId = true);
    }

    public interface ITermsSubRepository : IBaseRepository<TermsSubModel>
    {
    }

    public interface IMonthlySalesRepository : IBaseRepository<MonthlySalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IPaymentTypeRepository : ISelfRepository<PaymentTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDownTrading();
        IEnumerable<SelectListItem> GetAllForDropDownDeliveryService();

    }




    public interface IGatePassRepository : IBaseRepository<GatePassModel>
    {
       
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

    }
    public interface ITokenSalesRepository : IBaseRepository<TokenSalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

    }
    public interface IGatePassItemsRepository : IBaseRepository<GatePassItemsModel>
    {
    }

}

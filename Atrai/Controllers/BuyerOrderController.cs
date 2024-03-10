using DataTablesParser;
using Atrai.Core.Common;
using Atrai.Core.Entity;
using Atrai.Core.Interfaces;
using Atrai.Core.ViewModel;
using Atrai.Data.Repository;
using Atrai.Migrations;
using Atrai.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Atrai.Controllers.AdminController;
using static Atrai.Controllers.ValuesController;
using DocumentFormat.OpenXml.Bibliography;
using Atrai.Data.AppDataContext;
using DocumentFormat.OpenXml.Office.CustomUI;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;
using System.ComponentModel.Design;
using NuGet.Protocol.Plugins;
using System.Xml.Schema;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using static Atrai.Controllers.PurchaseController;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Http.Metadata;
using DocumentFormat.OpenXml.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class BuyerOrderController : Controller
    {
        public TransactionLogRepository tranlog { get; }


        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IReportStyleRepository reportStyleRepository;

        private readonly ICustomerRepository customerRepository;
        private readonly IUserAccountRepository UserAccountRepository;
        private readonly IUnitMasterRepository unitMasterRepository;
        private readonly INotifyPartyRepository notifyPartyRepository;
        private readonly IExportInvoiceMasterRepository exportInvoiceMasterRepository;
        private readonly IExportInvoiceDetailsRepository exportInvoiceDetailsRepository;
        private readonly IExportInvoicePackingListRepository exportInvoicepackingListRepository;
        private readonly IExportRealizationMasterRepository exporRealizationMasterRepository;
        private readonly IExportRealizationDetailsRepository exporRealizationDetailsRepository;

        private readonly ISupplierRepository supplierRepository;
        private readonly ITermsMainRepository termsmainRepository;
        private readonly IRecurringDetailsRepository recurringDetailsRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IBOMAllocationCategoryRepository bomAllocationCatRepository;
        private readonly IBOMMasterRepository bomMasterRepository;
        private readonly IBOMDetailsRepository bomDetailsRepository;
        private readonly IMasterPOConsumptionRepository masterPOConsumptionRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICommercialRepository commercialCompanyRepository;
        private readonly IBuyerGroupRepository buyerGroupRepository;
        private readonly IBankAccountNoRepository bankAccountNoRepository;
        private readonly ISupplierBankAccountRepository supplierBankAccountNoRepository;
        private readonly ILCTypeRepository lCTypeRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPostOfLoadingRepository loadingRepository;
        private readonly IPostOfDischargeRepository dischargeRepository;
        private readonly IDayListRepository dayListRepository;
        private readonly IIncoTermRepository tradeTermRepository;
        private readonly IDestinationRepository destinationRepository;
        private readonly IShipModeRepository shipModeRepository;
        private readonly IMasterLCRepository masterLCRepository;
        private readonly IMasterLCDetailsRepository masterLCDetailsRepository;


        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }

        private readonly IOrdersRepository onlineOrderRepository;
        private readonly IOrdersItemsRepository orderItemRepository;
        private readonly ISalesTagRepository salesTagRepository;
        private readonly ICustomFormStyleRepository _customFormStyleRepository;
        private readonly ITagsRepository tagsRepository;

        private readonly ISalesItemsRepository saleItemRepository;
        private readonly ISalesReturnItemsRepository salesReturnItemRepository;
        private readonly ISalesProductTaxRepository salesProductTaxRepository;


        private readonly ISalesBatchItemsRepository _salesBatchItemRepository;
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;

        private readonly ISalesPaymentRepository salesPaymentRepository;
        private readonly ISalesTermsRepository salesTermsRepository;
        private readonly ITransactionRepository _accountsDailyTransaction;
        private readonly ITransactionDetailsRepository _transactionDetailsRepository;

        private readonly IBrandRepository brandRepository;
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IStoreSettingRepository _storeSettingRepository;
        private readonly IStyleRepository _styleRepository;

        private readonly IPurchaseItemsRepository purchaseItemsRepository;
        private readonly IPurchasePaymentRepository purchasePaymentRepository;

        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IConfiguration configuration;
        private readonly ICompanyRepository companyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IConcernBankRepository concernBankRepository;

        private readonly IProductRepository productRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IFromWarehousePermissionRepository _FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;

        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;
        private readonly IDailyProduction_MasterRepository dailyProductionMasterRepository;
        private readonly IDailyProduction_DetailsRepository dailyProductionDetailsRepository;
        private readonly ILCStatusRepository lcStatusRepository;



        private readonly IAccountHeadRepository accountHeadRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeZoneSettingsRepository _timeZoneSettingsRepository;

        private readonly ICountryRepository _currencyRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;
        private readonly IBuyerPO_MasterRepository buyerPOMasterRepository;
        private readonly IBuyerPO_DetailsRepository buyerPODetailsRepository;
        private readonly IPaymentTermsRepository paymentTermsRepository;


        private readonly IGatePassRepository gatePassRepository;
        private readonly IGatePassItemsRepository gatePassItemRepository;

        private readonly ICostCalculatedRepository costCalculatedRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICreditBalanceRepository _CreditBalanceRepository;
        private readonly ICreditUsedRepository _creditUsedRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly ISalesTaxRepository _salestaxRepository;
        private readonly IMasterSalesTaxRepository _mastersalestaxRepository;
        private readonly IHttpContextAccessor httpcontext;
        private readonly ITermsMainRepository _termsMainRepository;
        private readonly ITermRepository _termRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISizesRepository sizesRepository;
        private readonly IColorChildRepository _colorChildRepository;
        private readonly ISizeChildRepository _sizeChildRepository;
        private readonly IColorsRepository colorsRepository;
        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public BuyerOrderController(ICustomerRepository customerRepository, IUserAccountRepository UserAccountRepository, ISaleRepository saleRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository, IStoreSettingRepository storeSettingRepository, IRecurringDetailsRepository recurringDetailsRepository, IColorsRepository colorsRepository, IColorChildRepository colorChildRepository, ISizeChildRepository sizeChildRepository,
            ITransactionRepository transactionRepository, ISizesRepository sizesRepository, IBuyerPO_MasterRepository buyerPOMasterRepository,
            ISalesItemsRepository saleItemRepository, ISalesBatchItemsRepository saleBatchItemRepository, ISalesPaymentRepository salesPaymentRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository, ICostCalculatedRepository costCalculatedRepository, INotifyPartyRepository notifyPartyRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, ITagsRepository tagsRepository,
        ITransactionDetailsRepository transactionDetailsRepository, IProductTypeRepository productTypeRepository, IBrandRepository brandRepository, ISalesTagRepository salesTagRepository, IStyleRepository styleRepository, IBuyerPO_DetailsRepository buyerPODetailsRepository, IMasterPOConsumptionRepository masterPOConsumptionRepository, IDepartmentRepository departmentRepository, IDailyProduction_MasterRepository dailyProductionMasterRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository, IBuyerGroupRepository buyerGroupRepository,
            IWarehouseRepository _warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository, IBOMAllocationCategoryRepository bomAllocationCatRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository, ICustomFormStyleRepository customFormStyleRepository,
            IExportRealizationMasterRepository exporRealizationMasterRepository, IExportRealizationDetailsRepository exporRealizationDetailsRepository,
            IExportInvoiceMasterRepository exportInvoiceMasterRepository,IExportInvoiceDetailsRepository exportInvoiceDetailsRepository, IExportInvoicePackingListRepository exportInvoicepackingListRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IReportStyleRepository reportStyleRepository, IOrdersRepository onlineOrderRepository, IOrdersItemsRepository orderItemRepository, IDocTypeRepository docTypeRepository, ICreditBalanceRepository sMSBalanceRepository, ICreditUsedRepository creditUsedRepository, IEmailSender emailsender, ISmsSender smsSender, IAccountHeadPermissionRepository accountHeadPermissionRepository, IMenuPermissionRepository menuPermissionRepository, ITermsMainRepository termsmainRepository, ICountryRepository currencyRepository, IEmployeeRepository employeeRepository, ISalesTermsRepository salesTermsRepository, ITransactionRepository accountsDailyTransaction, ISalesReturnItemsRepository salesReturnItemRepository, IGatePassRepository gatePassRepository, IGatePassItemsRepository gatePassItemRepository, IAgencyRepository agencyRepository, ISalesTaxRepository salestaxRepository, IMasterSalesTaxRepository masterSalesTaxRepository, ISalesProductTaxRepository salesProductTaxRepository, IFeedbackRepository feedbackRepository, ICountryRepository countryRepository, IPostOfLoadingRepository loadingRepository, IPostOfDischargeRepository dischargeRepository,
            IAccountCategoryRepository accountCategoryRepository, IBOMMasterRepository bomMasterRepository, IBOMDetailsRepository bomDetailsRepository,
IPaymentTermsRepository paymentTermsRepository, IDailyProduction_DetailsRepository dailyProductionDetailsRepository, ICommercialRepository commercialCompanyRepository, IConcernBankRepository concernBankRepository, ILCTypeRepository lCTypeRepository, IBankAccountNoRepository bankAccountNoRepository, IUnitMasterRepository unitMasterRepository, IDayListRepository dayListRepository, ILCStatusRepository lcStatusRepository, IIncoTermRepository tradeTermRepository, IDestinationRepository destinationRepository, IShipModeRepository shipModeRepository, IMasterLCRepository masterLCRepository, IMasterLCDetailsRepository masterLCDetailsRepository,
        ITermsMainRepository termsMainRepository, ITermRepository termRepository, IWebHostEnvironment webHostEnvironment, ISupplierBankAccountRepository supplierBankAccountNoRepository)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.brandRepository = brandRepository;
            this.saleRepository = saleRepository;
            this.saleItemRepository = saleItemRepository;
            this.exportInvoiceMasterRepository = exportInvoiceMasterRepository;
            this.exportInvoiceDetailsRepository = exportInvoiceDetailsRepository;
            this.exporRealizationMasterRepository = exporRealizationMasterRepository;
            this.exporRealizationDetailsRepository = exporRealizationDetailsRepository;
            this.tradeTermRepository = tradeTermRepository;
            this.masterLCRepository = masterLCRepository;
            this.lCTypeRepository = lCTypeRepository;
            this._salesBatchItemRepository = saleBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;
            this.paymentTermsRepository = paymentTermsRepository;
            this.concernBankRepository = concernBankRepository;
            this.exportInvoicepackingListRepository = exportInvoicepackingListRepository;
            this.salesTagRepository = salesTagRepository;
            this.lcStatusRepository = lcStatusRepository;
            this.salesPaymentRepository = salesPaymentRepository;
            this.salesProductTaxRepository = salesProductTaxRepository;
            this.productTypeRepository = productTypeRepository;
            this.recurringDetailsRepository = recurringDetailsRepository;
            this.notifyPartyRepository = notifyPartyRepository;
            this.destinationRepository = destinationRepository;
            this.dailyProductionMasterRepository = dailyProductionMasterRepository;
            this.dischargeRepository = dischargeRepository;
            this.shipModeRepository = shipModeRepository;
            this._storeSettingRepository = storeSettingRepository;
            this.supplierRepository = supplierRepository;
            this.purchaseRepository = purchaseRepository;
            this.commercialCompanyRepository = commercialCompanyRepository;
            this.buyerGroupRepository = buyerGroupRepository;
            this.countryRepository = countryRepository;
            this.dayListRepository = dayListRepository;
            this.loadingRepository = loadingRepository;
            this.masterLCDetailsRepository = masterLCDetailsRepository;
            this.unitMasterRepository = unitMasterRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.bankAccountNoRepository = bankAccountNoRepository;
            this.departmentRepository = departmentRepository;
            this.purchasePaymentRepository = purchasePaymentRepository;
            this.dailyProductionDetailsRepository = dailyProductionDetailsRepository;
            this.tagsRepository = tagsRepository;
            this.transactionRepository = transactionRepository;
            this.sizesRepository = sizesRepository;
            this.buyerPODetailsRepository = buyerPODetailsRepository;
            this.buyerPOMasterRepository = buyerPOMasterRepository;
            this.colorsRepository = colorsRepository;
            this.masterPOConsumptionRepository = masterPOConsumptionRepository;
            _styleRepository = styleRepository;
            _colorChildRepository = colorChildRepository;
            _sizeChildRepository = sizeChildRepository;
            this.costCalculatedRepository = costCalculatedRepository;
            this.storeSettingRepository = storeSettingRepository;
            this.companyRepository = companyRepository;
            this.categoryRepository = categoryRepository;
            _unitRepository = unitRepository;
            _customFormStyleRepository = customFormStyleRepository;
            this.productRepository = productRepository;
            this._warehouseRepository = _warehouseRepository;
            _FromWarehousePermissionRepository = FromWarehousePermissionRepository;
            this.ToWarehousePermissionRepository = ToWarehousePermissionRepository;
            this.accountCategoryRepository = accountCategoryRepository;
            _feedbackRepository = feedbackRepository;
            this.accountHeadRepository = accountHeadRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            tranlog = tranlogRepository;
            this.reportStyleRepository = reportStyleRepository;
            this.onlineOrderRepository = onlineOrderRepository;
            this.orderItemRepository = orderItemRepository;
            _docTypeRepository = docTypeRepository;
            _CreditBalanceRepository = sMSBalanceRepository;
            _creditUsedRepository = creditUsedRepository;
            _emailsender = emailsender;
            _smsSender = smsSender;
            AccountHeadPermissionRepository = accountHeadPermissionRepository;
            _menuPermissionRepository = menuPermissionRepository;
            this.termsmainRepository = termsmainRepository;
            _currencyRepository = currencyRepository;
            _employeeRepository = employeeRepository;
            this.salesTermsRepository = salesTermsRepository;
            _accountsDailyTransaction = accountsDailyTransaction;
            this.salesReturnItemRepository = salesReturnItemRepository;
            this.gatePassRepository = gatePassRepository;
            this.gatePassItemRepository = gatePassItemRepository;
            _agencyRepository = agencyRepository;
            _salestaxRepository = salestaxRepository;
            _mastersalestaxRepository = masterSalesTaxRepository;
            this.bomAllocationCatRepository = bomAllocationCatRepository;
            this.bomMasterRepository = bomMasterRepository;
            this.bomDetailsRepository = bomDetailsRepository;
            httpcontext = new HttpContextAccessor();
            _termsMainRepository = termsMainRepository;
            _termRepository = termRepository;
            _webHostEnvironment = webHostEnvironment;
            _transactionDetailsRepository = transactionDetailsRepository;
            this.supplierBankAccountNoRepository = supplierBankAccountNoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Order Allocation
        [AllowAnonymous]
        [HttpGet]
        public IActionResult BuyerPO(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;
            
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetColumnsName(int styleId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyerId = _styleRepository.All().Where(x=> x.Id == styleId).FirstOrDefault().BuyerId;

            SqlParameter[] sqlParameter1 = new SqlParameter[2];
            sqlParameter1[0] = new SqlParameter("@Comid", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetSizes", sqlParameter1);

            var dataTable1 = datasetabc.Tables[0];
            var dataTable2 = datasetabc.Tables[1];

            var dataList = new List<SelectListItem>();
            var colordataList = new List<SelectListItem>();

            foreach (DataRow row in dataTable1.Rows)
            {
                var id = Convert.ToInt32(row["Id"]);
                var sizeName = row["SizeName"].ToString();

                var selectListItem = new SelectListItem
                {
                    Value = id.ToString(),
                    Text = sizeName
                };
                dataList.Add(selectListItem);
            }

            foreach (DataRow row in dataTable2.Rows)
            {
                var id = Convert.ToInt32(row["Id"]);
                var colorname = row["ColorName"].ToString();

                var selectListItem = new SelectListItem
                {
                    Value = id.ToString(),
                    Text = colorname
                };
                colordataList.Add(selectListItem);
            }


            return Json(new { Success = 1, data = dataList, colordata = colordataList, buyerId = buyerId, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        public JsonResult GetBuyers()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = customerRepository.All().Where(x => x.ComId == ComId)
                .Include(x => x.Currency)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.CustomerCurrencyId,
                    x.Currency.CurrencyShortName,
                    x.ComId
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult SearchStyle(string term)
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var styles = _styleRepository.All()
                .Where(e => e.StyleNo.Contains(term) && e.ComId == comid)
                .Select(e => new { label = e.StyleNo, value = e.Id })
                .Take(10)
                .ToList();

            return new JsonResult(styles);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult BuyerPOCreation([FromBody] BuyerPO_MasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            
            if (model.Id == 0)
            {
                
                try
                {
                    buyerPOMasterRepository.Insert(model);
                    
                    return Json(new { error = false, message = "Order Allocation saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {

                buyerPOMasterRepository.Update(model, model.Id);

                var data = buyerPODetailsRepository.All().Where(x => x.BuyerPOId == model.Id).ToList();
                foreach (var item in data)
                {
                    buyerPODetailsRepository.Delete(item);
                }

                foreach (var item in model.BuyerPO_Details)
                {
                    item.BuyerPOId = model.Id;
                    item.Id = 0;

                    buyerPODetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "Order Allocation Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult BuyerPOList(string Type)
        {
            ViewBag.ListType = Type ?? "Order";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOrderList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = buyerPOMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Buyers)
                                                        .Include(x => x.Style)
                                                        .Select(x => new {
                                                            Id = x.Id,
                                                            BuyerName = x.Buyers.CompanyName,  
                                                            StyleName = x.Style.StyleNo,    
                                                            BuyerPO = x.BuyerPO,
                                                            UnitPrice = x.UnitPrice,    
                                                            TotalQuantity = x.TotalQuantity,    
                                                        })
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetOrderDetails(int id)
        {

            var masterdata = buyerPOMasterRepository.All().Include(x => x.Style).Where(x=>x.Id == id).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@Comid", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterdata.StyleId);
            sqlParameter1[2] = new SqlParameter("@Id", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetSizes", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1,masterdata = masterdata, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveOrder(int Id)
        {
            try
            {
                var data = buyerPOMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                buyerPOMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        #endregion
        
        #region BOM

        [AllowAnonymous]
        [HttpGet]
        public IActionResult BOM(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;
            ViewBag.CategoryId = categoryRepository.GetAllForDropDown();
            ViewBag.BrandId = brandRepository.GetAllForDropDown();
            ViewBag.ModelId = productRepository.GetModelDropDown(); 
            SelectListItem abc = new SelectListItem() { Text = "Warehouse", Value = "" };
            var x = _FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                x.Append(abc);
            }
            else
            {
                x.Append(abc);
            }
            ViewBag.WarehouseId = x.ToList();

            ViewBag.ColorList = colorsRepository.GetAllForDropDown();

            ViewBag.SizeList = sizesRepository.GetAllForDropDown();

            ViewBag.BOMAllocationCat = bomAllocationCatRepository.GetAllForDropDown();

            return View();
        }

        [AllowAnonymous]
        public JsonResult GetColor()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var color = colorsRepository.GetAllForDropDown();
            return Json(color);
        }

        [AllowAnonymous]
        public JsonResult GetSize()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var size = sizesRepository.GetAllForDropDown();
            return Json(size);
        }

        

        [AllowAnonymous]
        [HttpPost]
        public IActionResult BOMCreation([FromBody] BOMMasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {

                try
                {
                    if(model.BOMDetails.Count > 0 && model.BOMDetails != null)
                    {
                        foreach(var item in  model.BOMDetails)
                        {
                            item.ComId = ComId ?? 0;
                        }
                    }
                    bomMasterRepository.Insert(model);

                    return Json(new { error = false, message = "BOM saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {

                bomMasterRepository.Update(model, model.Id);

                var data = bomDetailsRepository.All().Where(x => x.BOMMasterId == model.Id && (x.ComId == 0 || x.ComId == ComId)).ToList();
                foreach (var item in data)
                {
                    bomDetailsRepository.Delete(item);
                }

                foreach (var item in model.BOMDetails)
                {
                    item.BOMMasterId = model.Id;
                    item.Id = 0;

                    bomDetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "BOM Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetBOMList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = bomMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Style)
                                                        .Include(x => x.Colors)
                                                        .Include(x => x.Sizes)
                                                        .Select(x => new {
                                                            Id = x.Id,
                                                            BOMCode = x.BOMCode,
                                                            Style = x.Style.StyleNo,
                                                            Color = x.Colors.ColorName,
                                                            Size = x.Sizes.SizeName,
                                                        })
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveBOM(int Id)
        {
            try
            {
                var data = bomMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                bomMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBOMDetails(int id)
        {
            var searchquery = bomMasterRepository.All().Where(x => x.Id == id);

            var data = searchquery
                .Include(x => x.Style)
                .Include(x => x.Colors)
                .Include(x => x.Sizes)
                .Select(x => new
                {
                    x.Id,
                    x.StyleId,
                    StyleNo = x.Style.StyleNo,
                    x.ColorId,
                    x.SizeId,
                    x.BOMCode,
                    BOMDetails = x.BOMDetails.Where(x => x.IsDelete == false).Select(a => new
                    {
                        a.Id,
                        a.Remarks1,
                        a.Remarks2,
                        a.ProductId,
                        Name = a.Product.Name,
                        PCategoryId = a.Product.CategoryId,
                        PCategoryName = a.Product.Category.Name,
                        BOMAllocationCategoryName = a.BOMAllocationCategory.Name,
                        a.BOMAllocationCategoryId,
                        ColorName = a.Colors.ColorName,
                        ColorId = a.ColorId,
                        SizeName = a.Sizes.SizeName,
                        a.SizeId,
                        UnitName = a.Product.Unit.UnitName,
                        UnitId = a.Product.UnitId,
                        RunTimeLiveStock = a.Quantity,
                        a.Price,
                        a.Amount
                    }).ToList()

                }).FirstOrDefault();

            return Json(new { success = "1", msg = "Deleted Successfully" , data = data});
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMDetailsWithProcess(int styleid, int orderAllocationId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var zero = 0;

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleid);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", orderAllocationId);
            sqlParameter1[3] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_OrderConsumption", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMDetails(int styleid, int orderAllocationId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleid);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", orderAllocationId);
            sqlParameter1[3] = new SqlParameter("@IsView", 1);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_OrderConsumption", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMConDetails(int masterPOId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            int zero = 0;
            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@MasterPOId", masterPOId);
            sqlParameter1[2] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_MasterPOOrderConsumptionSheet", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];

            return Json(new { Success = 1, data = dataTable, pivotData = dataTable1, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMConDetailsView(int masterPOId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            int zero = 1;
            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@MasterPOId", masterPOId);
            sqlParameter1[2] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_MasterPOOrderConsumptionSheet", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];

            return Json(new { Success = 1, data = dataTable, pivotData = dataTable1, ex = "Data Loaded Successfully" });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpgradeSupplierForDetails([FromBody] List<SupplierDetailsModel> data)
        {

            foreach (var item in data)
            {
                var model = masterPOConsumptionRepository.All().Where(x=>x.Id == item.Id).FirstOrDefault();
                model.SupplierId = item.SupplierId;
                masterPOConsumptionRepository.Update(model, model.Id);

            }

            return Json(new { Success = 1, ex = "Supplier Upgraded Successfully" });
        }

        public class SupplierDetailsModel
        {
            public int Id { get; set; }
            public int SupplierId { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpgradeSupplierForPivot([FromBody] List<SupplierPivotModel> data)
        {

            foreach (var item in data)
            {
                var model = masterPOConsumptionRepository.All().Where(x => x.MasterPOId == item.Id && x.ProductId == item.ProductId).ToList();
                foreach(var x in model)
                {
                    x.SupplierId = item.SupplierId;
                    masterPOConsumptionRepository.Update(x, x.Id);
                }
                

            }

            return Json(new { Success = 1, ex = "Supplier Upgraded Successfully" });
        }

        public class SupplierPivotModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int SupplierId { get; set; }
        }

        #endregion

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterPOConsumption(int SupplierId, int MasterId, int PurchaseId)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                SqlParameter[] sqlParameter1 = new SqlParameter[4];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@MasterPOId", MasterId);
                sqlParameter1[2] = new SqlParameter("@SupplierId", SupplierId);
                sqlParameter1[3] = new SqlParameter("@PurchaseId", PurchaseId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("get_MasterPOConsumption", sqlParameter1);

                var data = datasetabc.Tables[0];

                return Json(new { success = "1", msg = "Data retrieved successfully", data = data });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Json(new { success = "0", msg = "An error occurred while fetching data", data = ex.Message });
            }
        }


        #region Daily Production

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DailyProduction(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            return View();
        }

        [AllowAnonymous]
        public JsonResult GetBuyersPO()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = buyerPOMasterRepository.All().Where(x => x.ComId == ComId)
                .Select(x => new
                {
                    x.Id,
                    x.BuyerPO
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult GetDepartments()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = departmentRepository.All().Where(x => x.ComId == ComId)
                .Select(x => new
                {
                    x.Id,
                    x.DeptName
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult GetPODetails(int buyerPOId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterData = buyerPOMasterRepository.All().Where(x => x.Id == buyerPOId)
                .Include(x=>x.Style)
                .Select(
                x => new
                {
                    x.BuyerId,
                    x.StyleId,
                    x.UnitPrice,
                    StyleNo = x.Style.StyleNo
                }).FirstOrDefault();

            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterData.StyleId);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", buyerPOId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetGridForDailyProduction", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];


            return Json(new { success = "1", msg = "Data retrieved successfully", data = masterData, dataTable = dataTable, dataTable1 = dataTable1 });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DailyProductionCreation([FromBody] DailyProduction_MasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {

                try
                {
                    dailyProductionMasterRepository.Insert(model);

                    return Json(new { error = false, message = "Daily Production saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {

                dailyProductionMasterRepository.Update(model, model.Id);

                var data = dailyProductionDetailsRepository.All().Where(x => x.DailyProductionId == model.Id).ToList();

                dailyProductionDetailsRepository.RemoveRange(data);
                

                foreach (var item in model.DailyProduction_Details)
                {
                    item.DailyProductionId = model.Id;
                    item.Id = 0;
                    item.ReceivedQuantity = item.ReceivedQuantity;

                    dailyProductionDetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "Daily Production Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDailyProductionList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = dailyProductionMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Style)
                                                        .Include(x=>x.Buyers)
                                                        .Include(x=>x.BuyerPO_Master)
                                                        .Select(x => new {
                                                            Id = x.Id,
                                                            Style = x.Style.StyleNo,
                                                            Buyer = x.Buyers.Name,
                                                            BuyerPO = x.BuyerPO_Master.BuyerPO,
                                                            TotalQuantity = x.TotalQuantity
                                                        })
                                                        .ToList();

                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveDailyProduction(int Id)
        {
            try
            {
                var data = dailyProductionMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                dailyProductionMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDailyProductionDetails(int id)
        {

            var masterdata = dailyProductionMasterRepository.All().Include(x => x.Style).Where(x => x.Id == id).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterdata.StyleId);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", masterdata.BuyerPOId);
            sqlParameter1[3] = new SqlParameter("@DailyProductionId", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetGridForDailyProduction", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];
            var dataTable2 = datasetabc.Tables[2];

            return Json(new { Success = 1, masterdata = masterdata, data = dataTable,data1 = dataTable1, data2 = dataTable2, ex = "Data Loaded Successfully" });
        }
        #endregion


        #region MasterLC

        [AllowAnonymous]
        [HttpGet]
        public IActionResult MasterLC(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;
            var buyerPO = buyerPOMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList buyerPOList = new SelectList(buyerPO, "Id", "BuyerPO");
            ViewData["BuyerPOList"] = buyerPOList;

            return View();
        }

        [AllowAnonymous]
        public JsonResult GetComercialCompany()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var company = commercialCompanyRepository.GetAllForDropDown();
            return Json(company);
        }

        [AllowAnonymous]
        public JsonResult GetBuyerGroup()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyerGroup = buyerGroupRepository.GetAllForDropDown();
            return Json(buyerGroup);
        }
        
        [AllowAnonymous]
        public JsonResult GetBankAccountNo()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var bankAccount = bankAccountNoRepository.GetAllForDropDown();
            return Json(bankAccount);
        }

        [AllowAnonymous]
        public JsonResult GetConcernBank()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var concernBank = concernBankRepository.GetAllForDropDown();
            return Json(concernBank);
        }

        [AllowAnonymous]
        public JsonResult GetBuyerBank()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyerBank = supplierBankAccountNoRepository.GetAllForDropDown();
            return Json(buyerBank);
        }

        [AllowAnonymous]
        public JsonResult GetLCType()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var lctype = lCTypeRepository.GetAllForDropDown();
            return Json(lctype);
        }
        
        [AllowAnonymous]
        public JsonResult GetUnit()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var unit = unitMasterRepository.GetAllForDropDown();
            return Json(unit);
        }
        
        [AllowAnonymous]
        public JsonResult GetCurrencies()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = countryRepository.GetCurrencyList();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetTradeTerm()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var tradeTerm = tradeTermRepository.GetAllForDropDown();
            return Json(tradeTerm);
        }

        [AllowAnonymous]
        public JsonResult GetLoadingPort()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = loadingRepository.GetAllForDropDown();
            return Json(currency);
        }
        [AllowAnonymous]
        public JsonResult GetDischargePort()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = dischargeRepository.GetAllForDropDown();
            return Json(currency);
        }
        
        [AllowAnonymous]
        public JsonResult GetPaymentTerms()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = paymentTermsRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetDaylist()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = dayListRepository.GetAllForDropDown();
            return Json(currency);
        }
        
        [AllowAnonymous]
        public JsonResult GetLCStatus()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = lcStatusRepository.GetAllForDropDown();
            return Json(status);
        }
        
        [AllowAnonymous]
        public JsonResult GetDestination()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = destinationRepository.GetAllForDropDown();
            return Json(status);
        }
        
        [AllowAnonymous]
        public JsonResult GetShipMode()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = shipModeRepository.GetAllForDropDown();
            return Json(status);
        }

        [AllowAnonymous]
        public JsonResult GetSupplier()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var supplier = supplierRepository.GetAllForDropDown();
            return Json(supplier);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getBuyerPODetails(int BuyerPOId)
        {
            var buyerpo = buyerPOMasterRepository.All().Where(x => x.Id == BuyerPOId).Include(x=>x.Style).FirstOrDefault();
            
            return Json(new { Success = 1, data = buyerpo, ex = "Data no found" });
        }

        [AllowAnonymous]
        public JsonResult GetBuyerPOSearchList(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = buyerPOMasterRepository.All().Include(x => x.Style).Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<BuyerPOListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();  
                        pageSize = searchitem.pageSize.GetValueOrDefault();  

                    }


                    if (searchitem.BuyerPO != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.BuyerPO.ToLower().Contains(searchitem.BuyerPO.ToLower())); 
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.BuyerPO.ToLower().Contains(dropdownSearch.ToLower()) );
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Include(x => x.Style).Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                BuyerPO = e.BuyerPO,
                                StyleName = e.Style.StyleNo,
                                UnitPrice = e.UnitPrice,
                                TotalValue = e.TotalAmount,
                                OrderQty = e.TotalQuantity
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, BuyerPOList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult MasterLCCreation([FromBody] MasterLCModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            
            if (model.Id == 0)
            {
                masterLCRepository.Insert(model);
                return Json(new { error = false, message = "Master LC saved successfully" });

            }
            else
            {

                masterLCRepository.Update(model, model.Id);

                var data = masterLCDetailsRepository.All().Where(x => x.MasterLCID == model.Id).ToList();
                foreach (var item in data)
                {
                    masterLCDetailsRepository.Delete(item);
                }

                foreach (var item in model.COM_MasterLC_Details)
                {
                    item.MasterLCID = model.Id;
                    item.Id = 0;

                    masterLCDetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "Master LC Updated successfully"});

            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCDetails(int id)
        {

            var data = masterLCRepository.All().Where(x => x.Id == id).Include(x=>x.COM_MasterLC_Details);

            var query = (from e in data
                         select new
                         {
                            e.Id,
                            e.CommercialCompanyId ,
                            e.BuyerGroupID ,
                            e.BuyerID ,
                            e.LCMargin ,
                            e.BankAccountId ,
                            e.OpeningBankId ,
                            e.LienBankId ,
                            e.LCTypeId ,
                            e.LCRefNo ,
                            e.MasterLCValueManual ,
                            e.ExportLCValueManual ,
                            e.SalesContractIssueDate ,
                            e.LCExpirydate,
                            e.unitId,
                            e.CurrencyId,
                            e.BuyerLCRef,
                            e.LCOpenDate,
                            e.TotalLCQty,
                            e.LCValue,
                            e.TradeTermId,
                            e.PortOfLoadingId,
                            e.PortOfDischargeId,
                            e.DestinationId,
                            e.ShipModeId,
                            e.PaymentTermsId,
                            e.DayListId,
                            e.LCStatusId,
                            e.DestinationContract,
                            e.Remarks,
                            e.FileNo,
                            e.LCNOforImport,
                            COM_MasterLC_Details = e.COM_MasterLC_Details.Select(x => new
                            {
                                x.Id,
                                x.ExportPONo,
                                x.BuyerPOId,
                                BuyerPO = x.BuyerPOId != null ? x.BuyerPO_Master.BuyerPO : null,
                                x.StyleName,
                                x.ItemName ,
                                x.HSCode ,
                                x.Fabrication ,
                                x.OrderQty,
                                x.Factor,
                                x.QtyInPcs,
                                x.UnitPrice,
                                x.TotalValue,
                                x.ShipmentDate,
                                x.Destination,
                                x.ContractNo,
                                x.OrderType,
                                x.isTransaction,
                                x.CatNo,
                                x.DeliveryNo,
                                x.DestinationPO,
                                x.Kimball,
                                x.ColorCode,
                                x.ContractDate,
                            })


                         }).FirstOrDefault();



            return Json(new { Success = 1, data = query, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Export(string Type)
        {
            ViewBag.ListType = Type ?? "MasterLC";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetMasterLCList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = masterLCRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.CommercialCompanies)
                                                        .Include(x => x.BuyerGroups)
                                                        .Include(x => x.BuyerInformations)
                                                        .Include(x=>x.OpeningBank)
                                                        .Include(x=>x.LienBank)
                                                        .Select(x => new {
                                                            Id = x.Id,
                                                            Company = x.CommercialCompanies.CompanyName,
                                                            BuyerGroup = x.BuyerGroups.BuyerGroupName,
                                                            Buyer = x.BuyerInformations.Name,
                                                            ConcernBank = x.OpeningBank.OpeningBankName,
                                                            BuyerBank = x.LienBank.LienBankName,
                                                        })
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveMasterLC(int Id)
        {
            try
            {
                var data = masterLCRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                masterLCRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }
        #endregion

        #region ExportInvoice


        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExportInvoice(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            //var buyerPO = buyerPOMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            //SelectList buyerPOList = new SelectList(buyerPO, "Id", "BuyerPO");
            //ViewData["BuyerPOList"] = buyerPOList;

            return View();
        }

        [AllowAnonymous]
        public JsonResult GetMasterLC()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterLC = masterLCRepository.All().Where(p => p.ComId == ComId).ToList();

            foreach(var item in masterLC)
            {
                if(item.LCRefNo == null)
                {
                    item.LCRefNo = "Not found";
                }
            }

            SelectList masterLCList = new SelectList(masterLC, "Id", "LCRefNo");
            return Json(masterLCList);
        }

        [AllowAnonymous]
        public JsonResult GetNotifyParty()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var notify = notifyPartyRepository.GetAllForDropDown();
            return Json(notify);
        }


        [AllowAnonymous]
        public JsonResult GetExportInvoiceList(int MasterLCId,int Id, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");

                var invoice = exportInvoiceMasterRepository.All().Where(x=>x.Id != Id && x.MasterLCId == MasterLCId);

                if (searchquery?.Length > 1)
                {
                    

                }

                


                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;



                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.InvoiceNo,
                                 e.InvoiceDate,
                                 e.TotalInvoiceQty,
                                 e.TotalValue,
                                 Destination = e.COM_MasterLC.Destination.DestinationName
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCData(int MasterLCId, int Id)
        {

            var data = masterLCRepository.All().Where(x => x.Id == MasterLCId).Include(x => x.COM_MasterLC_Details);

            var totalShipped = exportInvoiceMasterRepository.All().Where(x => x.MasterLCId == MasterLCId && x.Id != Id).Sum(x => x.TotalInvoiceQty);
            if(totalShipped == null)
            {
                totalShipped = 0;
            }

            var query = (from e in data
                         select new
                         {
                             e.Id,
                             e.BuyerGroupID,
                             e.DestinationId,
                             e.BuyerID,
                             e.CommercialCompanyId,
                             e.PortOfLoadingId,
                             e.PortOfDischargeId,
                             TotalLCQty = e.COM_MasterLC_Details.Sum(x => x.OrderQty),
                             e.ShipModeId,
                             TotalShipped = totalShipped,
                             TotalCartonQty = e.COM_MasterLC_Details.Sum(x=>x.QtyInPcs),
                             COM_MasterLC_Details = e.COM_MasterLC_Details.Select(x => new
                             {
                                 MasterLCDetailsID = x.Id,
                                 ExportOrderNo = x.ExportPONo,
                                 StyleNo = x.StyleName,
                                 x.ShipmentDate,
                                 x.Destination,
                                 LCQty = x.OrderQty,
                                 InvoiceQty = x.OrderQty,
                                 UnitMasterId = e.unitId,
                                 UnitMasterName = e.UnitMaster.UnitName,
                                 x.UnitPrice,
                                 InvoiceRate = x.UnitPrice,
                                 InvoiceValue = Convert.ToDouble(x.UnitPrice) * x.OrderQty,
                                 x.TotalValue,
                                 x.DestinationPO,
                                 x.ContractDate
                             })

                         }).FirstOrDefault();
            



            return Json(new { Success = 1, data = query, ex = "Data Loaded Successfully" });
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExportInvoiceCreation([FromBody] ExportInvoiceMaster model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {
                exportInvoiceMasterRepository.Insert(model);
                return Json(new { error = false, message = "Export Invoice saved successfully" });

            }
            else
            {

                exportInvoiceMasterRepository.Update(model, model.Id);

                var data = exportInvoiceDetailsRepository.All().Where(x => x.ExportInvoiceMasterId == model.Id).ToList();
                foreach (var item in data)
                {
                    exportInvoiceDetailsRepository.Delete(item);
                }

                foreach (var item in model.ExportInvoiceDetails)
                {
                    item.ExportInvoiceMasterId = model.Id;
                    item.Id = 0;

                    exportInvoiceDetailsRepository.Insert(item);

                    //foreach(var child in item.ExportInvoicePackingLists)
                    //{
                    //    child.Id = 0;
                    //    child.ExportInvoiceDetailsId = item.Id;

                    //    exportInvoicepackingListRepository.Insert(child);
                    //}
                }

                return Json(new { error = false, message = "Export Invoice Updated successfully" });

            }

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetExportInvoiceDetails(int id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@Id", id);
            sqlParameter1[1] = new SqlParameter("@Comid", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetExportInvoiceDetails", sqlParameter1);

            var masterTable = datasetabc.Tables[0];
            var detailsTable = datasetabc.Tables[1];
            var packingTable = datasetabc.Tables[2];

            return Json(new { Success = 1, data = masterTable, details = detailsTable, packing = packingTable, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        public JsonResult GetExpInvoiceList( int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");

                var invoice = exportInvoiceMasterRepository.All();

                if (searchquery?.Length > 1)
                {


                }




                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;



                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.InvoiceNo,
                                 Destination = e.COM_MasterLC.Destination.DestinationName,
                                 e.InvoiceDate,
                                 e.ExpNo,
                                 e.ExpDate,
                                 e.BLNo,
                                 e.BLDate,
                                 e.TotalValue,
                                 NotifyParty = e.NotifyPartyFirst.NotifyPartyName,
                                 e.TotalCartonQty,
                                 e.NetWeight,
                                 e.GrossWeight
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveExportInvoice(int Id)
        {
            try
            {
                var data = exportInvoiceMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                exportInvoiceMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetNonZeroOrderQtyMasterLC(int MasterLCId)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@MasterLCId", MasterLCId);
            sqlParameter1[1] = new SqlParameter("@Comid", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_NonZeroOrderQtyMasterLC", sqlParameter1);

            var masterTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });
        }
        #endregion

        #region Realization

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Realization(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCForRealization(int MasterLCId, int Id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyer = masterLCRepository.All().Where(x => x.Id == MasterLCId).Select(x => x.BuyerInformations.Name).FirstOrDefault();

            if(Id > 0)
            {
                MasterLCId = exporRealizationMasterRepository.All().Where(x=>x.Id == Id).Select(x => x.MasterLCId).FirstOrDefault() ?? MasterLCId;
            }

            SqlParameter[] sqlParameter1 = new SqlParameter[3];

            sqlParameter1[0] = new SqlParameter("@MasterLCId", MasterLCId);
            sqlParameter1[1] = new SqlParameter("@ComId", ComId);
            sqlParameter1[2] = new SqlParameter("@Id", Id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_MasterLCDataForRealization", sqlParameter1);

            if(Id == 0)
            {
                var masterTable = datasetabc.Tables[0];


                return Json(new { Success = 1, buyer = buyer, data = masterTable, ex = "Data Loaded Successfully" });
            }
            else
            {
                var masterTable = datasetabc.Tables[0];
                var detailsTable = datasetabc.Tables[1];
                var modalTable = datasetabc.Tables[2];


                return Json(new { Success = 1, buyer = buyer, data = masterTable,details = detailsTable, modal = modalTable, ex = "Data Loaded Successfully" });
            }
            
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult RealizationCreation([FromBody] ExportRealization_Master model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {
                exporRealizationMasterRepository.Insert(model);
                return Json(new { error = false, message = "Realization saved successfully" });

            }
            else
            {

                exporRealizationMasterRepository.Update(model, model.Id);

                var data = exporRealizationDetailsRepository.All().Where(x => x.RealizationId == model.Id).ToList();
                foreach (var item in data)
                {
                    exporRealizationDetailsRepository.Delete(item);
                }

                foreach (var item in model.ExportRealization_Details)
                {
                    item.RealizationId = model.Id;
                    item.Id = 0;

                    exporRealizationDetailsRepository.Insert(item);

                    //foreach(var child in item.ExportInvoicePackingLists)
                    //{
                    //    child.Id = 0;
                    //    child.ExportInvoiceDetailsId = item.Id;

                    //    exportInvoicepackingListRepository.Insert(child);
                    //}
                }

                return Json(new { error = false, message = "Realization Updated successfully" });

            }

        }

        [AllowAnonymous]
        public JsonResult GetRealizationList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");

                var invoice = exporRealizationMasterRepository.All();

                if (searchquery?.Length > 1)
                {


                }




                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;



                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.FileNumber,
                                 e.FBPNo,
                                 e.FBPDate,
                                 e.BankRef,
                                 e.CourierNo,
                                 e.TotalValue,
                                 ReceivingValue = e.ReceivingVlaue,
                                 e.BankCharge,
                                 e.Remarks
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveRealization(int Id)
        {
            try
            {
                var data = exporRealizationMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                exporRealizationMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }
        #endregion
    }
}

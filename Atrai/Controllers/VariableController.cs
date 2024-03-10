using Atrai.Core.Entity;
using Atrai.Core.Interfaces;
using Atrai.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Atrai.Controllers.AccountsController;
using System.Linq;
using System;
using Atrai.Migrations;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2010.Excel;
using Atrai.Core.Common;
using Microsoft.Data.SqlClient;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Atrai.Controllers
{
    public class VariableController : Controller
    {

        private readonly ICommercialRepository commercialRepository;
        private readonly ILCTypeRepository _LCTypeRepository;
        private readonly IPostOfLoadingRepository portOfLoadingRepository;
        private readonly IPostOfDischargeRepository portOfDischargeRepository;
        private readonly IShipModeRepository shipModeRepository;
        private readonly IIncoTermRepository incoTermRepository;
        private readonly IDayListTermRepository dayListTermRepository;
        private readonly ITradeTermRepository dayTermDecTermRepository;
        private readonly IDestinationRepository destinationRepository;
        private readonly IItemGroupRepository itemGroupRepository;
        private readonly IItemDescriptionRepository itemDescriptionRepository;
        private readonly IBuyerGroupRepository buyerGroupRepository;
        private readonly INotifyPartyRepository notifyPartyRepository;
        private readonly IDynamicReportRepository dynamicReportRepository;
        private readonly ILienBankRepository lienBankRepository;
        private readonly ISupplierBankAccountRepository supplierBankAccountRepository;
        private readonly IBankAccountNoRepository bankAccountNoRepository;
        private readonly ICOM_ProformaInvoiceRepository proformaInvoiceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IConcernBankRepository concernBankRepository;
        private readonly IPITypeRepository pITypeRepository;
        private readonly IGroupLCMainRepository groupLCMainRepository;
        private readonly IGroupLCSubRepository groupLCSubRepository;
        private readonly IBBLCMainRepository _bBLCMainRepository;
        private readonly IBBLCDetailsRepository _bBLCDetailsRepository;
        private readonly IUnitRepository unitRepository;
        private readonly IPaymentTermsRepository paymentTermsRepository;
        private readonly IDayListRepository dayListRepository;
        private readonly IMasterLCRepository _masterLCRepository;
        private readonly IMasterLCDetailsRepository _masterLCDetailsRepository;
        private readonly ICOM_CommercialInvoiceRepository _CommercialInvoiceRepository;
        private readonly ICOM_CommercialInvoice_SubRepository _CommercialInvoice_SubRepository;
        private readonly ICOM_MachinaryLC_MasterRepository _MachinaryLC_MasterRepository;
        private readonly ICOM_MachinaryLC_DetailsRepository _MachinaryLC_DetailsRepository;
        private readonly IDocumentStatusRepository _DocumentStatusRepository;
        private readonly ICommercialLCTypeRepository _CommercialLCTypeRepository;
        private readonly IDocumentAcceptance_MasterRepository _DocumentAcceptance_MasterRepository;
        private readonly IDocumentAcceptance_DetailsRepository _DocumentAcceptance_DetailsRepository;
        private readonly ICOM_ProformaInvoice_SubInvoiceRepository _ProformaInvoiceSubInvoiceRepository;
        private readonly IWorkOrderMasterRepository _WorkOrderMasterRepository;
        private readonly ICOM_MachineryLCDetailsRepository _MachineryLCDetailsRepository;
        private readonly ICOM_MachineryLCMasterRepository _MachineryLCMasterRepository;
        private readonly IApprovedByRepository _ApprovedByRepository;
        private readonly IWorkorderStatusRepository _WorkorderStatusRepository;
        private readonly ITruckInfoRepository _TruckInfoRepository;

        public VariableController(ICommercialRepository _commercialRepository, IPostOfLoadingRepository portOfLoadingRepository, ICountryRepository countryRepository, IPostOfDischargeRepository portOfDischargeRepository, IDestinationRepository destinationRepository, IItemGroupRepository itemGroupRepository, IItemDescriptionRepository itemDescriptionRepository, IBuyerGroupRepository buyerGroupRepository, ICustomerRepository customerRepository, INotifyPartyRepository notifyPartyRepository, IDynamicReportRepository dynamicReportRepository, ILienBankRepository lienBankRepository, IBankAccountNoRepository bankAccountNoRepository, ISupplierRepository supplierRepository, IEmployeeRepository employeeRepository, IPaymentTermsRepository paymentTermsRepository, IConcernBankRepository concernBankRepository, ICOM_ProformaInvoiceRepository proformaInvoiceRepository, IPITypeRepository pITypeRepository, IGroupLCMainRepository groupLCMainRepository, IUnitRepository unitRepository, IDayListRepository dayListRepository, ISupplierBankAccountRepository supplierBankAccountRepository, IShipModeRepository shipModeRepository, IIncoTermRepository incoTermRepository, ITradeTermRepository dayTermDecTermRepository, IDayListTermRepository dayListTermRepository, IBBLCMainRepository _bBLCMainRepository, IBBLCDetailsRepository _bBLCDetailsRepository, IMasterLCRepository masterLCRepository, IMasterLCDetailsRepository masterLCDetailsRepository, IGroupLCSubRepository groupLCSubRepository, IDocumentStatusRepository documentStatusRepository, ICommercialLCTypeRepository commercialLCTypeRepository, ICOM_MachinaryLC_DetailsRepository machinaryLC_DetailsRepository, ICOM_MachinaryLC_MasterRepository machinaryLC_MasterRepository, ICOM_CommercialInvoice_SubRepository commercialInvoice_SubRepository, ICOM_CommercialInvoiceRepository commercialInvoiceRepository, ILCTypeRepository lCTypeRepository, IDocumentAcceptance_MasterRepository documentAcceptance_MasterRepository, IDocumentAcceptance_DetailsRepository documentAcceptance_DetailsRepository, ICOM_ProformaInvoice_SubInvoiceRepository proformaInvoiceSubInvoiceRepository, IWorkOrderMasterRepository workOrderMasterRepository, ICOM_MachineryLCDetailsRepository machineryLCDetailsRepository, ICOM_MachineryLCMasterRepository machineryLCMasterRepository, IApprovedByRepository approvedByRepository, IWorkorderStatusRepository workorderStatusRepository, ITruckInfoRepository truckInfoRepository)
        {
            commercialRepository = _commercialRepository;
            this.portOfLoadingRepository = portOfLoadingRepository;
            _countryRepository = countryRepository;
            this.portOfDischargeRepository = portOfDischargeRepository;
            this.destinationRepository = destinationRepository;
            this.itemGroupRepository = itemGroupRepository;
            this.itemDescriptionRepository = itemDescriptionRepository;
            this.buyerGroupRepository = buyerGroupRepository;
            this.customerRepository = customerRepository;
            this.notifyPartyRepository = notifyPartyRepository;
            this.dynamicReportRepository = dynamicReportRepository;
            this.lienBankRepository = lienBankRepository;
            this.bankAccountNoRepository = bankAccountNoRepository;
            this.supplierRepository = supplierRepository;
            this.employeeRepository = employeeRepository;
            this.paymentTermsRepository = paymentTermsRepository;
            this.concernBankRepository = concernBankRepository;
            this.proformaInvoiceRepository = proformaInvoiceRepository;
            this.pITypeRepository = pITypeRepository;
            this.groupLCMainRepository = groupLCMainRepository;
            this.unitRepository = unitRepository;
            this.dayListRepository = dayListRepository;
            this.supplierBankAccountRepository = supplierBankAccountRepository;
            this.shipModeRepository = shipModeRepository;
            this.incoTermRepository = incoTermRepository;
            this.dayTermDecTermRepository = dayTermDecTermRepository;
            this.dayListTermRepository = dayListTermRepository;
            this._bBLCMainRepository = _bBLCMainRepository;
            this._bBLCDetailsRepository = _bBLCDetailsRepository;
            _masterLCRepository = masterLCRepository;
            _masterLCDetailsRepository = masterLCDetailsRepository;
            this.groupLCSubRepository = groupLCSubRepository;
            _DocumentStatusRepository = documentStatusRepository;
            _CommercialLCTypeRepository = commercialLCTypeRepository;
            _MachinaryLC_DetailsRepository = machinaryLC_DetailsRepository;
            _MachinaryLC_MasterRepository = machinaryLC_MasterRepository;
            _CommercialInvoice_SubRepository = commercialInvoice_SubRepository;
            _CommercialInvoiceRepository = commercialInvoiceRepository;
            _LCTypeRepository = lCTypeRepository;
            _DocumentAcceptance_MasterRepository = documentAcceptance_MasterRepository;
            _DocumentAcceptance_DetailsRepository = documentAcceptance_DetailsRepository;
            _ProformaInvoiceSubInvoiceRepository = proformaInvoiceSubInvoiceRepository;
            _WorkOrderMasterRepository = workOrderMasterRepository;
            _MachineryLCDetailsRepository = machineryLCDetailsRepository;
            _MachineryLCMasterRepository = machineryLCMasterRepository;
            _ApprovedByRepository = approvedByRepository;
            _WorkorderStatusRepository = workorderStatusRepository;
            _TruckInfoRepository = truckInfoRepository;
        }


        // GET: VariableController
        public ActionResult Index()
        {
            return View();
        }
        public class PagingInfo
        {
            public int PageNo { get; set; }

            public int PageSize { get; set; }

            public int PageCount { get; set; }

            public long TotalRecordCount { get; set; }

        }

        #region pol  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SavePol([FromBody] PortOfLoading model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        portOfLoadingRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        portOfLoadingRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetPOLs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = portOfLoadingRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult InactivePOLs(int id)
        {
            try
            {
                var model = portOfLoadingRepository.Find(id);

                if (model != null)
                {
                    if (model.IsDelete == false)
                    {
                        model.IsDelete = true;
                        portOfLoadingRepository.Update(model, id);
                        return Json(new { success = "1", msg = "Deleted Successfully" });

                    }
                    else if (model.IsDelete == true)
                    {
                        model.IsDelete = false;
                        portOfLoadingRepository.Update(model, id);
                        return Json(new { success = "1", msg = "Restored Successfully." });
                    }

                }
                return Json(new { success = "0", msg = "No items found to Inactivate." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." });
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPOL(int id)
        {
            try
            {
                var colorsquery = portOfLoadingRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PortOfLoadingName,
                      p.PortCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeletePOLs(int id)
        {
            try
            {


                var model = portOfLoadingRepository.Find(id);

                if (model != null)
                {

                    portOfLoadingRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetPOLList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = portOfLoadingRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(
                        x => x.PortOfLoadingName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist //.Include(x=>x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.PortOfLoadingName,
                                e.PortCode,
                                e.CountryId,
                                polcountry=e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetSizeSearchList(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var productlist = portOfLoadingRepository.All().Where(x => x.IsDelete == false);
                if (searchquery?.Length > 1)
                {
                    var searchitem = JsonConvert.DeserializeObject<SizeListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault();


                    }
                    if (searchitem.SizeName != null)
                    {
                        productlist = productlist.Where(x => x.PortOfLoadingName.ToLower().Contains(searchitem.SizeName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }
                    if (searchitem.SizeCode != null)
                    {
                        productlist = productlist.Where(x => x.PortCode.ToLower().Contains(searchitem.SizeCode.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }
                }
                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    productlist = productlist.Where(x => x.PortOfLoadingName.ToLower().Contains(dropdownSearch.ToLower()) || x.PortCode.ToLower().Contains(dropdownSearch.ToLower()));
                }
                decimal TotalRecordCount = productlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                int total = productlist.Count();
                var query = from e in productlist
                            select new
                            {
                                id = e.Id,
                                text = e.PortOfLoadingName,
                                e.PortCode,
                                e.CountryId,
                                e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, ProductList = abcd, PageInfo = pageinfo });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCountryDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = _countryRepository.All();
            return Json(countries);
        }
        #endregion


        #region pod  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SavePod([FromBody] PortOfDischarge model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        portOfDischargeRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        portOfDischargeRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetPODs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = portOfDischargeRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPOD(int id)
        {
            try
            {
                var colorsquery = portOfDischargeRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PortOfDischargeName,
                      podCode = p.PortCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeletePODs(int id)
        {
            try
            {


                var model = portOfDischargeRepository.Find(id);

                if (model != null)
                {

                    portOfDischargeRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetPODList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = portOfDischargeRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.PortOfDischargeName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x=>x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.PortOfDischargeName,
                                podCode=e.PortCode,
                                e.CountryId,
                                podcountry=e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region fd  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveFD([FromBody] Destination model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        destinationRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        destinationRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetFDs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = destinationRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetFD(int id)
        {
            try
            {
                var colorsquery = destinationRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.DestinationNameSearch,
                      p.DestinationName,
                      p.DestinationCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteFDs(int id)
        {
            try
            {


                var model = destinationRepository.Find(id);

                if (model != null)
                {

                    destinationRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetFDList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = destinationRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.DestinationNameSearch.ToLower().Contains(searchquery.ToLower()) ||
                        x.DestinationCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.DestinationName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.DestinationNameSearch,
                                e.DestinationName,
                                e.DestinationCode,
                                e.CountryId,
                                fdcountry=e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ig  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveIG([FromBody] ItemGroupModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        itemGroupRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        itemGroupRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetIG(int id)
        {
            try
            {
                var colorsquery = itemGroupRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.ItemGroupCode,
                      p.ItemGroupHSCode,
                      p.ItemGroupShortName,
                      p.ItemGroupName,
                      p.ItemMargin,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteIGs(int id)
        {
            try
            {


                var model = itemGroupRepository.Find(id);

                if (model != null)
                {

                    itemGroupRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetIGList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = itemGroupRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.ItemGroupName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroupCode.ToLower().Contains(searchquery.ToLower())||
                        x.ItemGroupHSCode.ToLower().Contains(searchquery.ToLower())||
                        x.ItemMargin.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.ItemGroupShortName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.ItemGroupCode,
                                p.ItemGroupHSCode,
                                p.ItemGroupShortName,
                                p.ItemGroupName,
                                p.ItemMargin,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion







        #region IT  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveIT([FromBody] ItemDescriptionModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        itemDescriptionRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        itemDescriptionRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetIT(int id)
        {
            try
            {
                var colorsquery = itemDescriptionRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.ItemDescCode,
                      p.ItemDescHSCode,
                      p.ItemDescShortName,
                      p.ItemDescName,
                      p.ItemGroupId,
                      p.ItemGroups.ItemGroupName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteITs(int id)
        {
            try
            {


                var model = itemDescriptionRepository.Find(id);

                if (model != null)
                {

                    itemDescriptionRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetITList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = itemDescriptionRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.ItemDescName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescCode.ToLower().Contains(searchquery.ToLower())||
                        x.ItemDescHSCode.ToLower().Contains(searchquery.ToLower())||
                        x.ItemDescShortName.ToLower().Contains(searchquery.ToLower())||
                        x.ItemGroups.ItemGroupName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x=>x.ItemGroups)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.ItemDescCode,
                                p.ItemDescHSCode,
                                p.ItemDescShortName,
                                p.ItemDescName,
                                p.ItemGroupId,
                                igName=p.ItemGroups.ItemGroupName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetItemGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = itemGroupRepository.All();
            return Json(countries);
        }
        #endregion





        #region dr  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveDP([FromBody] DynamicReport model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        dynamicReportRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        dynamicReportRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDP(int id)
        {
            try
            {
                var colorsquery = dynamicReportRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.DynamicReportName,
                      p.DynamicReportPackingListName,
                      p.DynamicReportPackingDetailsName,
                      p.DynamicReportCaption,
                      p.BuyerId,
                      p.BuyerInformations.Name,
                      p.ReportController,
                      p.DynamicReportActionName,
                      p.ReportDesignByPerson,
                      p.ReportLocation,
                      p.VerifiedByPerson,
                      p.CompletePercentage,
                      p.Remarks,
                      p.isVerified,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteDPs(int id)
        {
            try
            {


                var model = dynamicReportRepository.Find(id);

                if (model != null)
                {

                    dynamicReportRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDPList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = dynamicReportRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.DynamicReportName.ToLower().Contains(searchquery.ToLower())||
                        x.DynamicReportPackingListName.ToLower().Contains(searchquery.ToLower())||
                        x.DynamicReportPackingDetailsName.ToLower().Contains(searchquery.ToLower())||
                        x.DynamicReportCaption.ToLower().Contains(searchquery.ToLower())||
                        x.DynamicReportActionName.ToLower().Contains(searchquery.ToLower())||
                        x.ReportDesignByPerson.ToLower().Contains(searchquery.ToLower())||
                        x.ReportLocation.ToLower().Contains(searchquery.ToLower())||
                        x.ReportController.ToLower().Contains(searchquery.ToLower())||
                        x.VerifiedByPerson.ToLower().Contains(searchquery.ToLower())||
                        x.CompletePercentage.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.Remarks.ToLower().Contains(searchquery.ToLower())||
                        x.BuyerInformations.DisplayName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x=>x.BuyerInformations)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.DynamicReportName,
                                p.DynamicReportPackingListName,
                                p.DynamicReportPackingDetailsName,
                                p.DynamicReportCaption,
                                p.BuyerId,
                                dpbuyer=p.BuyerInformations.Name,
                                p.ReportController,
                                p.DynamicReportActionName,
                                p.ReportDesignByPerson,
                                p.ReportLocation,
                                p.VerifiedByPerson,
                                p.CompletePercentage,
                                p.Remarks,
                                p.isVerified,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region np  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveNP([FromBody] NotifyParty model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        notifyPartyRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        notifyPartyRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetNP(int id)
        {
            try
            {
                var colorsquery = notifyPartyRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.NotifyPartyName,
                      p.NotifyPartyNameSearch,
                      p.ShopCode,
                      p.Email,
                      p.IsDelete,
                      p.SLNO,
                      p.BuyerId,
                      p.buyers.Name,
                      p.CountryId,
                      p.Countrys.CountryName,
                      p.PortOfDischargeId,
                      p.PortOfDischarge.PortOfDischargeName,
                      p.PhoneNo,
                      p.Address1,
                      p.Address2,
                      p.ShippedTo,
                      p.isInactive,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteNPs(int id)
        {
            try
            {


                var model = notifyPartyRepository.Find(id);

                if (model != null)
                {

                    notifyPartyRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetNPList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = notifyPartyRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.NotifyPartyName.ToLower().Contains(searchquery.ToLower()) ||
                        x.NotifyPartyNameSearch.ToLower().Contains(searchquery.ToLower())||
                        x.Address1.ToLower().Contains(searchquery.ToLower())||
                        x.Address2.ToLower().Contains(searchquery.ToLower())||
                        x.PhoneNo.ToLower().Contains(searchquery.ToLower())||
                        x.Email.ToLower().Contains(searchquery.ToLower())||
                        x.buyers.DisplayName.ToLower().Contains(searchquery.ToLower())||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())||
                        x.PortOfDischarge.PortOfDischargeName.ToLower().Contains(searchquery.ToLower())||
                        x.ShopCode.ToLower().Contains(searchquery.ToLower())||
                        x.ShippedTo.ToLower().Contains(searchquery.ToLower())||
                        x.SLNO.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.DynamicReports.DynamicReportName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.Countrys).Include(x=>x.PortOfDischarge).Include(x=>x.buyers)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.NotifyPartyName,
                                p.NotifyPartyNameSearch,
                                p.ShopCode,
                                p.Email,
                                p.IsDelete,
                                p.SLNO,
                                p.BuyerId,
                                p.buyers.Name,
                                p.CountryId,
                                npcountry=p.Countrys.CountryName,
                                p.PortOfDischargeId,
                                nppod=p.PortOfDischarge.PortOfDischargeName,
                                p.PhoneNo,
                                p.Address1,
                                p.Address2,
                                p.ShippedTo,
                                p.isInactive,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBuyerGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = customerRepository.All();
            return Json(countries);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBuyerGroupDrodpwonForGroupLC()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = customerRepository.GetAllForDropDown();
            return Json(countries);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPODGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = portOfDischargeRepository.All();
            return Json(countries);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetReportLinkGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = dynamicReportRepository.GetAllForDropDown();
            return Json(countries);
        }
        #endregion

        #region CI  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveBG([FromBody] BuyerGroup model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        buyerGroupRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        buyerGroupRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetBG(int id)
        {
            try
            {
                var colorsquery = buyerGroupRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.BuyerGroupName,
                      p.BuyerGroupShortName,
                      p.BuyerGroupCode,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteBGs(int id)
        {
            try
            {


                var model = buyerGroupRepository.Find(id);

                if (model != null)
                {

                    buyerGroupRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetBGList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = buyerGroupRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BuyerGroupName.ToLower().Contains(searchquery.ToLower())||
                        x.BuyerGroupCode.ToLower().Contains(searchquery.ToLower())||
                        x.BuyerGroupShortName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.BuyerGroupName,
                                p.BuyerGroupShortName,
                                p.BuyerGroupCode
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region CI  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveCI([FromBody] CommercialCompanyModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        commercialRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        commercialRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCI(int id)
        {
            try
            {
                var colorsquery = commercialRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.CompanyName,
                      p.CompanyShortName,
                      p.Address,
                      p.Address2,
                      p.PhoneNumber,
                      p.FactoryPhoneNumber,
                      p.FaxNumber,
                      p.EmailID,
                      p.Web,
                      p.TradeLicenceNo,
                      p.TINNo,
                      p.VATNo,
                      p.IRCNo,
                      p.BKMEARegNo,
                      p.ContactPerson,
                      p.ContactPersonDesignation,
                      p.BusinessType,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteCIs(int id)
        {
            try
            {


                var model = commercialRepository.Find(id);

                if (model != null)
                {

                    commercialRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetCIList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = commercialRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.CompanyName.ToLower().Contains(searchquery.ToLower())||
                        x.CompanyShortName.ToLower().Contains(searchquery.ToLower())||
                        x.Address.ToLower().Contains(searchquery.ToLower())||
                        x.Address2.ToLower().Contains(searchquery.ToLower())||
                        x.PhoneNumber.ToLower().Contains(searchquery.ToLower())||
                        x.FactoryPhoneNumber.ToLower().Contains(searchquery.ToLower())||
                        x.FaxNumber.ToLower().Contains(searchquery.ToLower())||
                        x.EmailID.ToLower().Contains(searchquery.ToLower())||
                        x.Web.ToLower().Contains(searchquery.ToLower())||
                        x.TradeLicenceNo.ToLower().Contains(searchquery.ToLower())||
                        x.TINNo.ToLower().Contains(searchquery.ToLower())||
                        x.VATNo.ToLower().Contains(searchquery.ToLower())||
                        x.IRCNo.ToLower().Contains(searchquery.ToLower())||
                        x.BKMEARegNo.ToLower().Contains(searchquery.ToLower())||
                        x.ContactPerson.ToLower().Contains(searchquery.ToLower())||
                        x.ContactPersonDesignation.ToLower().Contains(searchquery.ToLower())||
                        x.BusinessType.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.CompanyName,
                                p.CompanyShortName,
                                p.Address,
                                ciadrs2=p.Address2,
                                p.PhoneNumber,
                                p.FactoryPhoneNumber,
                                p.FaxNumber,
                                p.EmailID,
                                p.Web,
                                p.TradeLicenceNo,
                                p.TINNo,
                                p.VATNo,
                                p.IRCNo,
                                p.BKMEARegNo,
                                p.ContactPerson,
                                p.ContactPersonDesignation,
                                p.BusinessType,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region LB  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveLB([FromBody] LienBank model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        lienBankRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        lienBankRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetLB(int id)
        {
            try
            {
                var colorsquery = lienBankRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.LienBankName,
                      p.CountryId,
                      p.SwiftCode,
                      p.LienBankAccountNo,
                      p.BranchAddress,
                      p.BranchAddress2,
                      p.PhoneNo,
                      p.Remarks,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteLBs(int id)
        {
            try
            {


                var model = lienBankRepository.Find(id);

                if (model != null)
                {

                    lienBankRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetLBList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = lienBankRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.LienBankName.ToLower().Contains(searchquery.ToLower())||
                        x.Country.CountryName.ToLower().Contains(searchquery.ToLower())||
                        x.SwiftCode.ToLower().Contains(searchquery.ToLower())||
                        x.LienBankAccountNo.ToLower().Contains(searchquery.ToLower())||
                        x.BranchAddress.ToLower().Contains(searchquery.ToLower())||
                        x.BranchAddress2.ToLower().Contains(searchquery.ToLower())||
                        x.PhoneNo.ToLower().Contains(searchquery.ToLower())||
                        x.Remarks.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x=>x.Country)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.LienBankName,
                                p.CountryId,
                                lbcountry = p.Country.CountryName,
                                p.SwiftCode,
                                p.LienBankAccountNo,
                                p.BranchAddress,
                                p.BranchAddress2,
                                lbphone=p.PhoneNo,
                                p.Remarks,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region BA  region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveBA([FromBody] BankAccountNo model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        bankAccountNoRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        bankAccountNoRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetBA(int id)
        {
            try
            {
                var colorsquery = bankAccountNoRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.BankAccountNumber,
                      p.CommercialCompanyId,
                      p.OpeningBankId,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteBAs(int id)
        {
            try
            {


                var model = bankAccountNoRepository.Find(id);

                if (model != null)
                {

                    bankAccountNoRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetLBAist(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = bankAccountNoRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BankAccountNumber.ToLower().Contains(searchquery.ToLower())||
                        x.CommercialCompanies.CompanyName.ToLower().Contains(searchquery.ToLower())||
                        x.OpeningBanks.OpeningBankName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x=>x.CommercialCompanies).Include(x => x.OpeningBanks)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.BankAccountNumber,
                                p.CommercialCompanyId,
                                bacom =p.CommercialCompanies.CompanyName,
                                p.OpeningBankId,
                                babank = p.OpeningBanks.OpeningBankName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult commercialCompanyDropdown()
        {
            var dropdown = commercialRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult oepningBankDropdown()
        {
            var dropdown = lienBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion

        public IActionResult Import()
        {
            return View();
        }

        #region proforma invoice region
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveProforma([FromBody] COM_ProformaInvoice model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        proformaInvoiceRepository.Update(model, model.Id);

                        var previousitem = _ProformaInvoiceSubInvoiceRepository.All().Where(x => x.PIId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.COM_ProformaInvoice_Subs.Any(z => x.Id == z.Id)).ToList();
                        _ProformaInvoiceSubInvoiceRepository.RemoveRange(tmp);

                        foreach (COM_ProformaInvoice_Sub item in model.COM_ProformaInvoice_Subs)
                        {
                            if (item.Id > 0)
                            {
                                item.PIId = model.Id;
                                _ProformaInvoiceSubInvoiceRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.PIId = model.Id;
                                _ProformaInvoiceSubInvoiceRepository.Insert(item);

                            }
                        }

                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        foreach (var item in model.COM_ProformaInvoice_Subs)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.PIId = model.Id;
                        }
                        proformaInvoiceRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetProforma(int id)
        {
            try
            {
                var colorsquery = proformaInvoiceRepository.All().Where(x => x.Id == id);

                var color = colorsquery.Include(p=>p.COM_ProformaInvoice_Subs).Include(p=>p.COM_GroupLC_Mains)
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PINo,
                      PIDate=p.PIDate.ToString("dd-MMM-yyyy"),
                      PIReceivingDate=p.PIReceivingDate.ToString("dd-MMM-yyyy"),
                      p.CommercialCompanyId,
                      p.CurrencyId,
                      p.SupplierId,
                      p.ImportPONo,
                      p.FileNo,
                      p.ItemGroupId,
                      p.ItemGroups,
                      p.GroupLCId,
                      p.COM_GroupLC_Mains.GroupLCRefName,
                      p.ItemGroupName,
                      p.Size,
                      p.Remarks,
                      p.ImportQty,
                      p.UnitId,
                      p.ImportRate,
                      p.CartonRollQty,
                      p.TotalValue,
                      p.HSCode,
                      p.EmployeeId,
                      p.MerchandiserName,
                      p.RevNo,
                      p.PaymentTermsId,
                      p.DayListId,
                      p.OpeningBankId,
                      p.BankAccountId,
                      p.LienBankId,
                      p.PITypeId,
                      p.PortOfLoadingId,
                      p.PortOfLoadingDestinationId,
                      p.COM_ProformaInvoice_Subs,
                      //COM_ProformaInvoice_Subs = p.COM_ProformaInvoice_Subs.Select(y => new
                      //{
                      //    ItemDescId=y.ItemDescId
                      //}),
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = color, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteProformas(int id)
        {
            try
            {


                var model = proformaInvoiceRepository.Find(id);
                var modelItemDesc = _ProformaInvoiceSubInvoiceRepository.All().Where(x=>x.PIId==id).ToList();

                if (model != null)
                {

                    _ProformaInvoiceSubInvoiceRepository.RemoveRange(modelItemDesc);
                    proformaInvoiceRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetProformaList(string fromDate="", string toDate="", int supplierid =0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = proformaInvoiceRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.PINo.ToLower().Contains(searchquery.ToLower())||
                        x.PIDate.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.PIReceivingDate.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.CommercialCompanies.CompanyName.ToLower().Contains(searchquery.ToLower())||
                        x.Currencies.CountryName.ToLower().Contains(searchquery.ToLower())||
                        x.Suppliers.SupplierName.ToLower().Contains(searchquery.ToLower())||
                        x.ImportPONo.ToLower().Contains(searchquery.ToLower())||
                        x.FileNo.ToLower().Contains(searchquery.ToLower())||
                        x.LCAF.ToLower().Contains(searchquery.ToLower())||
                        x.ItemDescList.ToLower().Contains(searchquery.ToLower())||
                        x.ItemGroups.ItemGroupName.ToLower().Contains(searchquery.ToLower())||
                        x.COM_GroupLC_Mains.GroupLCRefName.ToLower().Contains(searchquery.ToLower())||
                        x.ItemGroupName.ToLower().Contains(searchquery.ToLower())||
                        x.ItemDescs.ItemDescName.ToLower().Contains(searchquery.ToLower())||
                        x.Size.ToLower().Contains(searchquery.ToLower())||
                        x.Remarks.ToLower().Contains(searchquery.ToLower())||
                        x.ImportQty.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.ImportRate.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.CartonRollQty.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.TotalValue.ToString().ToLower().Contains(searchquery.ToLower())||
                        x.HSCode.ToLower().Contains(searchquery.ToLower())||
                        x.employees.EmployeeName.ToLower().Contains(searchquery.ToLower())||
                        x.MerchandiserName.ToLower().Contains(searchquery.ToLower())||
                        x.RevNo.ToLower().Contains(searchquery.ToLower())||
                        x.UnitMaster.UnitName.ToLower().Contains(searchquery.ToLower())||
                        x.PaymentTerms.PaymentTermsName.ToLower().Contains(searchquery.ToLower())||
                        x.DayList.DayListName.ToLower().Contains(searchquery.ToLower())||
                        x.OpeningBanks.OpeningBankName.ToLower().Contains(searchquery.ToLower())||
                        x.BankAccountNos.BankAccountNumber.ToLower().Contains(searchquery.ToLower())||
                        x.LienBanks.LienBankName.ToLower().Contains(searchquery.ToLower())||
                        x.PITypes.PITytpeName.ToLower().Contains(searchquery.ToLower())||
                        x.PortOfLoading.PortOfLoadingName.ToLower().Contains(searchquery.ToLower())||
                        x.PortOfLoadingDestination.PortOfLoadingName.ToLower().Contains(searchquery.ToLower())||
                        x.PortOfLoadingCountryOfOrigin.PortOfLoadingName.ToLower().Contains(searchquery.ToLower())
                    );

                }


                if (supplierid >0)
                {
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.SupplierId == supplierid);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(toDate);
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date >= fromDateValue.Date);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x=>x.CommercialCompanies).Include(x => x.ItemDescs).Include(x => x.ItemDescs).Include(x=>x.ItemGroups)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.PINo,
                                p.COM_GroupLC_Mains.GroupLCAmdNo,
                                p.COM_GroupLC_Mains.GroupLCRefName,
                                p.Currencies.CountryShortName,
                                p.Suppliers.SupplierName,
                                p.UnitMaster.UnitName,
                                PIDate=p.PIDate.ToString("dd-MMM-yyyy"),
                                PIReceivingDate=p.PIReceivingDate.ToString("dd-MMM-yyyy"),
                                p.CommercialCompanyId,
                                p.CommercialCompanies.CompanyName,
                                p.CurrencyId,
                                p.SupplierId,
                                p.ImportPONo,
                                p.FileNo,
                                p.ItemGroupId,
                                p.ItemDescription,
                                p.ItemGroups.ItemGroupName,
                                p.GroupLCId,
                                p.ItemDescId,
                                p.ItemDescs.ItemDescName,
                                p.Size,
                                p.Remarks,
                                p.ImportQty,
                                p.UnitId,
                                p.ImportRate,
                                p.CartonRollQty,
                                p.TotalValue,
                                p.HSCode,
                                p.EmployeeId,
                                p.MerchandiserName,
                                p.RevNo,
                                p.PaymentTermsId,
                                p.DayListId,
                                p.OpeningBankId,
                                p.BankAccountId,
                                p.LienBankId,
                                p.PITypeId,
                                p.PortOfLoadingId,
                                p.PortOfLoadingDestinationId,
                                p.PortOfLoadingCountryOfOriginId,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //dropdowns starts==============================
        public IActionResult concernDrodpdown()
        {
            var dropdown = commercialRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult approvedByDrodpdown()
        {
            var dropdown = _ApprovedByRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult currencyDrodpdown()
        {
            var dropdown = _countryRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult supplierDrodpdown()
        {
            var dropdown = supplierRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult employeeDrodpdown()
        {
            var dropdown = employeeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult concernBankAccountDrodpdown()
        {
            var dropdown = bankAccountNoRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult concernBankDrodpdown()
        {
            var dropdown = concernBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult supplierBankDrodpdown()
        {
            var dropdown = supplierBankAccountRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult itemGroupDrodpdown()
        {
            var dropdown = itemGroupRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult piTypeDrodpdown()
        {
            var dropdown = pITypeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult itemDescriptionDrodpdown()
        {
            var dropdown = itemDescriptionRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult itemDescriptionDrodpdownTable()
        {
            var dropdown = itemDescriptionRepository.All().Select(x=> new
            {
                ItemDescId= x.Id
            });
            return Json(dropdown);
        }
        public IActionResult groupLCMainDrodpdown()
        {
            var dropdown = groupLCMainRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        [AllowAnonymous]
        public JsonResult GroupLCSearch(string query)
        {
            var abc = groupLCMainRepository.All()
                .Where(x => (x.GroupLCRefName.ToLower().Contains(query.ToLower()))).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.GroupLCRefName,
                        }).Take(10);

            return Json(abc);
        }
        public IActionResult qtyDrodpdown()
        {
            var dropdown = unitRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult paymentTermsDrodpdown()
        {
            var dropdown = paymentTermsRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult dayListDrodpdown()
        {
            var dropdown = dayListRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult countryOFOriginDrodpdown()
        {
            var dropdown = _countryRepository.All();
            return Json(dropdown);
        }

        public IActionResult portOFLoadingDrodpdown()
        {
            var dropdown = portOfLoadingRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult portOFDischargeDrodpdown()
        {
            var dropdown = portOfDischargeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion


        #region BBLC region
        public IActionResult CreateBackToBackLC(int backtobacklcid = 0)
        {

            if (backtobacklcid > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getMasterLCData(int groupLCid=0)
        {

            if (groupLCid > 0)
            {
                var groupLCDataa = proformaInvoiceRepository.All().Where(x => x.GroupLCId == groupLCid);

                var buyerId = groupLCMainRepository.All().Where(x => x.Id == groupLCid).FirstOrDefault().BuyerId;

                var sumAmount = groupLCMainRepository.All().Where(x => x.Id == groupLCid && x.Buyers.Id == buyerId).Sum(x => x.TotalGroupLCValue);

                var groupLCData = groupLCMainRepository.All().Where(x => x.Id == groupLCid)
                    .Select(x => new
                    {
                        buyerName = x.Buyers.Name,
                        Benificiary = "Benificiary",
                        ContactRef = x.GroupLCRefName,
                        LCDate = x.GroupLC_Sub.FirstOrDefault().MasterLC.LCOpenDate.ToString("dd-MMM-yyyy"),
                        Amount = x.TotalGroupLCValue

                    }).ToList();
                //var piid = groupLCDataa.FirstOrDefault().Id;


                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                var queryname = "getMasterLCData";
                var viewquery = $"Exec {queryname} '{ComId}','{groupLCid}','{0}'";
                Console.WriteLine(viewquery);
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@groupLCid ", groupLCid);
                parameters[2] = new SqlParameter("@PIID  ", 0);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS(queryname, parameters);


                var margin = _bBLCMainRepository.All().Where(x => x.GroupLCId == groupLCid).Sum(x=>x.Tenor);

                return Json(new { data = groupLCData, datasetabc = datasetabc, sumAmount = sumAmount, margin= margin });
            }
            return Json(new { data = "" });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult getProformaInvoiceData(int SupplierID = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getProformaInvoiceData";
            var viewquery = $"Exec {queryname} '{ComId}','{SupplierID}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@SupplierID ", SupplierID);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });
            //var proformaInvoice = proformaInvoiceRepository.All().Where(x=>x.SupplierId== SupplierID)
            //    .Select(x => new
            //    {
            //        piid=x.Id,
            //        x.PINo,
            //        x.ImportPONo,
            //        x.ItemGroups.ItemGroupName,
            //        x.ItemDescs.ItemDescName,
            //        x.ImportQty,
            //        x.ImportRate,
            //        x.TotalValue
            //    }).ToList();
            //return Json(new {data= proformaInvoice });
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveBBLC([FromBody] BBLCMain model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        _bBLCMainRepository.Update(model, model.Id);

                        var previousitem = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.BBLC_Details.Any(z => x.Id == z.Id)).ToList();
                        _bBLCDetailsRepository.RemoveRange(tmp);
                        foreach (BBLC_Details item in model.BBLC_Details)
                        {
                            if (item.Id > 0)
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {

                        foreach (var item in model.BBLC_Details.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.BBLCMainId = model.Id;
                        }
                        _bBLCMainRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getBBLCData(int id =0)
        {
            var getAllBBLC = _bBLCMainRepository.All().Where(x=>x.Id== id);
            var query = getAllBBLC.Include(x => x.BBLC_Details)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BBLCNo,
                    x.BBLCAmdNo,
                    x.UDNo,
                    x.AmdNo,
                    x.CommercialCompanyId,
                    x.ShipModeId,
                    x.GroupLCId,
                    x.TotalValue,
                    x.PaymentTerm,
                    x.PaymentTermsId,
                    x.DayListId,
                    x.DecreaseValue,
                    x.NetValue,
                    x.GroupLCAverage,
                    x.DayListTermId,
                    x.Insurance,
                    x.CurrencyId,
                    x.PortOfLoadingId,
                    x.PortOfDischargeId,
                    x.Percentage,
                    x.OpeningBankId,
                    x.Tenor,
                    x.LienBankId,
                    x.TradeTermId,
                    LcOpeningDate = x.LcOpeningDate != null ? x.LcOpeningDate.Value.ToString("dd-MMM-yyyy") : null,
                    ExpiryDate= x.ExpiryDate != null ? x.ExpiryDate.Value.ToString("dd-MMM-yyyy") : null,
                    UDDate= x.UDDate != null ? x.UDDate.Value.ToString("dd-MMM-yyyy") : null,
                    FirstShipmentDate = x.FirstShipmentDate != null ? x.FirstShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    LastShipmentDate = x.LastShipmentDate != null ? x.LastShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.DestinationID,
                    x.ConvertRate,
                    x.BBLCValue,
                    x.BBLCQty,
                    x.Balance,
                    x.PrevBBLCValue,
                    x.IncreaseValue,
                    x.SupplierId,
                    x.ItemGroupId,
                    BBLCDetails = x.BBLC_Details.Select(y => new
                    {
                        y.Id,
                        piid=y.PIId,
                        PINo=y.COM_ProformaInvoice.PINo,
                        ImportPONo=y.COM_ProformaInvoice.ImportPONo,
                        ItemGroupName=y.COM_ProformaInvoice.ItemGroups.ItemGroupName,
                        ItemDescName=y.COM_ProformaInvoice.ItemDescs.ItemDescName,
                        ImportQty=y.COM_ProformaInvoice.ImportQty,
                        ImportRate=y.COM_ProformaInvoice.ImportRate,
                        TotalValue=y.COM_ProformaInvoice.TotalValue,
                        y.BBLCMainId,
                        y.ComId
                    })
                }).FirstOrDefault();
            return Json(query);
        }

        [AllowAnonymous]
        public JsonResult BBLCSearch(string query)
        {
            //var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");

            ////|| (x.BrandName.ToLower().Contains(query.ToLower()))  need to check by fahad
            var abc = _bBLCMainRepository.All()
                .Where(x => (x.BBLCNo.ToLower().Contains(query.ToLower()))).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.BBLCNo,
                            p
                        }).Take(10);

            return Json(abc);
        }


        [AllowAnonymous]
        public JsonResult GetBBLCList(string fromDate = "", string toDate = "", int supplierid = 0,int concernid=0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch="")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _bBLCMainRepository.All();
                if (concernid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid);
                }
                if (supplierid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.SupplierId == supplierid);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = _bBLCMainRepository.All().Where(x => x.LcOpeningDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = _bBLCMainRepository.All().Where(x => x.ExpiryDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BBLCNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BBLCAmdNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo.ToLower().Contains(searchquery.ToLower()) ||
                        x.SupplierInformation.SupplierName.ToLower().Contains(searchquery.ToLower())
                    );

                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(dropdownSearch.ToLower()));
                }


                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.BBLC_Details).Include(x=>x.SupplierInformation).Include(x=>x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BBLCNo,
                                e.BBLCAmdNo,
                                e.SupplierId,
                                bblcCompanyName=e.CompanyList.CompanyName,
                                e.SupplierInformation.SupplierName,
                                bblcPINo=e.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public JsonResult DeleteBBLC(int id)
        {
            try
            {


                var model = _bBLCMainRepository.Find(id);
                var modelSub = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();

                if (model != null)
                {

                    _bBLCDetailsRepository.RemoveRange(modelSub);
                    _bBLCMainRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }


        public IActionResult shipModeDrodpdown()
        {
            var dropdown = shipModeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult incoTermDrodpdown()
        {
            var dropdown = incoTermRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult dayTermDescDrodpdown()
        {
            var dropdown = dayListTermRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult destinationDrodpdown()
        {
            var dropdown = destinationRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion


        #region GROUP LC region
        public IActionResult CreateGroupLC(int grouplcid = 0)
        {

            if (grouplcid > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.GroupLCID = grouplcid;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.GroupLCID = grouplcid;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getMasterLCDataForGroupLC(int buyerid = 0)
        {
            //var groupLCData = _masterLCRepository.All().Where(x => x.BuyerID == buyerid)
            //    .Select(x => new
            //    {
            //        MasterLCID = x.Id,
            //        x.ComId,
            //        x.LCRefNo,
            //        x.LCOpenDate,
            //        x.TotalLCQty,
            //        x.LCValue,
            //        x.ExportLCValueManual

            //    }).ToList();

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getMasterLCData";
            var viewquery = $"Exec {queryname} '{ComId}','{buyerid}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@BuyerID ", buyerid);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveGroupLC([FromBody] GroupLC_MainModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        groupLCMainRepository.Update(model, model.Id);

                        var previousitem = groupLCSubRepository.All().Where(x => x.GroupLCId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.GroupLC_Sub.Any(z => x.Id == z.Id)).ToList();
                        groupLCSubRepository.RemoveRange(tmp);
                        foreach (GroupLC_SubModel item in model.GroupLC_Sub)
                        {
                            if (item.Id > 0)
                            {
                                item.GroupLCId = model.Id;
                                groupLCSubRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.GroupLCId = model.Id;
                                groupLCSubRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {

                        foreach (var item in model.GroupLC_Sub.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.GroupLCId = model.Id;
                        }
                        groupLCMainRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getGroupLCData(int id = 0)
        {
            var getallGroupLC = groupLCMainRepository.All().Where(x => x.Id == id);
            var query = getallGroupLC.Include(x => x.GroupLC_Sub)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BuyerId,
                    x.CommercialCompanyId,
                    x.GroupLCAmdNo,
                    x.Margin,
                    x.FreightChargePer,
                    x.GroupLCRefName,
                    x.TotalGroupLCValue,
                    x.TotalGroupLCValueManual,
                    x.TotalGroupLCQty,
                    FirstShipDate = x.FirstShipDate != null ? x.FirstShipDate.Value.ToString("dd-MMM-yyyy") : null,
                    LastShipDate = x.LastShipDate != null ? x.LastShipDate.Value.ToString("dd-MMM-yyyy") : null,
                    GroupLc = x.GroupLC_Sub.Select(y => new
                    {
                        grouplcid = y.GroupLCId,
                        MasterLCID = y.MasterLCID,
                        LCRefNo = y.MasterLC.LCRefNo,
                        LCOpenDate = y.MasterLC.LCOpenDate.ToString("dd-MMM-yyyy"),
                        TotalLCQty = y.MasterLC.TotalLCQty,
                        LCValue = y.MasterLC.LCValue,
                        ExportLCValueManual = y.MasterLC.ExportLCValueManual,
                    })
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetGroupLCist(string fromDate = "", string toDate = "", int buyerId = 0, int concernid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = groupLCMainRepository.All();
                if (concernid > 0)
                {
                    purchaselist = groupLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid);
                }
                if (buyerId > 0)
                {
                    purchaselist = groupLCMainRepository.All().Where(x => x.BuyerId == buyerId);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = groupLCMainRepository.All().Where(x => x.FirstShipDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = groupLCMainRepository.All().Where(x => x.LastShipDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.GroupLCRefName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.GroupLC_Sub).Include(x => x.Buyers).Include(x => x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.GroupLCRefName,
                                e.GroupLCAmdNo,
                                e.Buyers.Name,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public JsonResult DeleteGroupLc(int id)
        {
            try
            {


                var model = groupLCMainRepository.Find(id);
                var modelSub = groupLCSubRepository.All().Where(x=>x.GroupLCId==model.Id).ToList();

                if (model != null)
                {

                    groupLCSubRepository.RemoveRange(modelSub);
                    groupLCMainRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        public IActionResult Export()
        {
            return View();
        }
        #endregion


        #region import commercial invoice region
        public IActionResult CreateCommercialInvoice(int commercialInvoiceId = 0)
        {

            if (commercialInvoiceId > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.commercialInvoiceId = commercialInvoiceId;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.commercialInvoiceId = commercialInvoiceId;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveCommercialInvoice([FromBody] COM_CommercialInvoice model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        _CommercialInvoiceRepository.Update(model, model.Id);
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _CommercialInvoiceRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getCommercialInvoiceData(int id = 0)
        {
            var getData = _CommercialInvoiceRepository.All().Where(x => x.Id == id);
            var query = getData
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.CommercialInvoiceNo,
                    CommercialInvoiceDate= x.CommercialInvoiceDate!=null ? x.CommercialInvoiceDate.Value.ToString("dd-MMM-yyyy"):null,
                    DocumentReceiptDate=x.DocumentReceiptDate != null ? x.DocumentReceiptDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.CommercialCompanyID,
                    x.CommercialLCTypeId,
                    x.CurrencyId,
                    x.ItemGroupId,
                    x.ItemDescId,
                    x.UnitMasterId,
                    x.BBLCId,
                    x.SupplierID,
                    x.DocumentStatusId,
                    x.BLNo,
                    BLDate = x.BLDate != null ? x.BLDate.Value.ToString("dd-MMM-yyyy") : null,
                    DocumentAssesmentDate = x.DocumentAssesmentDate != null ? x.DocumentAssesmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.Quantity,
                    x.TotalPI,
                    x.TotalValue,
                    x.ConversionRate,
                    x.BillOfEntryNo,
                    BillOfEntryDate = x.BillOfEntryDate != null ? x.BillOfEntryDate.Value.ToString("dd-MMM-yyyy") : null,
                    CustomAssesmentDate = x.CustomAssesmentDate != null ? x.CustomAssesmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.VasselETADate,
                    ETBDate = x.ETBDate != null ? x.ETBDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.MotherVassel,
                    GoodsInhouseDate = x.GoodsInhouseDate != null ? x.GoodsInhouseDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.Remarks,
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetCommercialInvoiceList(string fromDate = "", string toDate = "", int supplierId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _CommercialInvoiceRepository.All();
                if (supplierId > 0)
                {
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.SupplierID == supplierId);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.CommercialInvoiceDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.DocumentReceiptDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.CommercialInvoiceNo.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.CommercialInvoiceNo,
                                CommercialInvoiceDate = e.CommercialInvoiceDate != null ? e.CommercialInvoiceDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.CommercialLCTypes.CommercialLCTypeShortName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.CommercialCompany.CompanyName,
                                e.SupplierInformations.SupplierName,
                                e.Currency.CurrencyShortName,
                                e.Quantity,
                                e.UnitMaster.UnitShortName,
                                e.TotalValue,
                                e.ItemGroups.ItemGroupName,
                                e.ItemDescs.ItemDescName,
                                e.BLNo,
                                BLDate = e.BLDate != null ? e.BLDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.DocumentStatus.DocumentStatusShortName,
                                e.MotherVassel,
                                VasselETADate = e.VasselETADate != null ? e.VasselETADate.Value.ToString("dd-MMM-yyyy") : null,
                                e.BillOfEntryNo,
                                BillOfEntryDate = e.BillOfEntryDate != null ? e.BillOfEntryDate.Value.ToString("dd-MMM-yyyy") : null,
                                GoodsInhouseDate = e.GoodsInhouseDate != null ? e.GoodsInhouseDate.Value.ToString("dd-MMM-yyyy") : null,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public JsonResult DeleteCommercialInvoice(int id)
        {
            try
            {


                var model = _CommercialInvoiceRepository.Find(id);

                if (model != null)
                {
                    _CommercialInvoiceRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        //dropdowns
        public IActionResult lctypeDropdown()
        {
            var dropdown = _CommercialLCTypeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult bblcnoDropdown()
        {
            var dropdown = _bBLCMainRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult documentStatusDropdown()
        {
            var dropdown = _DocumentStatusRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        #endregion



        #region document acceptance region
        public IActionResult CreateDocumentAcceptance(int DocumentAcceptanceid = 0)
        {

            if (DocumentAcceptanceid > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.DocumentAcceptanceid = DocumentAcceptanceid;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.DocumentAcceptanceid = DocumentAcceptanceid;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getCommercialInvoiceProcData(int BBLCID = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getCommercialInvoiceData";
            var viewquery = $"Exec {queryname} '{ComId}','{BBLCID}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@BBLCID ", BBLCID);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveDocumentAcceptance([FromBody] COM_DocumentAcceptance_Master model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        _DocumentAcceptance_MasterRepository.Update(model, model.Id);

                        var previousitem = _DocumentAcceptance_DetailsRepository.All().Where(x => x.DocumentAcceptanceMasterId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.COM_DocumentAcceptance_Details.Any(z => x.Id == z.Id)).ToList();
                        _DocumentAcceptance_DetailsRepository.RemoveRange(tmp);
                        foreach (COM_DocumentAcceptance_Details item in model.COM_DocumentAcceptance_Details)
                        {
                            if (item.Id > 0)
                            {
                                item.DocumentAcceptanceMasterId = model.Id;
                                _DocumentAcceptance_DetailsRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.DocumentAcceptanceMasterId = model.Id;
                                _DocumentAcceptance_DetailsRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {

                        foreach (var item in model.COM_DocumentAcceptance_Details.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.DocumentAcceptanceMasterId = model.Id;
                        }
                        _DocumentAcceptance_MasterRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getDocumentAcceptanceData(int id = 0)
        {
            var getAllBBLC = _DocumentAcceptance_MasterRepository.All().Where(x => x.Id == id);
            var query = getAllBBLC.Include(x => x.COM_DocumentAcceptance_Details)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BillOfExchangeRef,
                    BillDate=x.BillDate != null ? x.BillDate.Value.ToString("dd-MMM-yyyy") : null ,
                    BillMaturityDate= x.BillMaturityDate != null ? x.BillMaturityDate.Value.ToString("dd-MMM-yyyy") : null,
                    BillPaymentDate = x.BillPaymentDate != null ? x.BillPaymentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.BBLCId,
                    x.COM_BBLC_Master.BBLCNo,
                    x.CommercialCompanyId,
                    x.SupplierId,
                    x.GroupLCId,
                    x.MasterLCId,
                    x.ConversionRate,
                    x.CurrencyId,
                    x.BuyerId,
                    //x.bblcamount,
                    //x.previousaccepted,
                    //x.payableamount,
                    //x.NewCIAmount,
                    DocumentCceptanceDetails = x.COM_DocumentAcceptance_Details.Select(y => new
                    {
                        y.Id,
                        y.ComId,
                        CommercialInvoiceId = y.CommercialInvoiceId,
                        y.DocumentAcceptanceMasterId,
                        y.COM_CommercialInvoice.CommercialInvoiceNo,
                        y.COM_CommercialInvoice.ConversionRate,
                        y.COM_CommercialInvoice.Currency.CurrencyShortName,
                        y.COM_CommercialInvoice.ItemGroups.ItemGroupShortName,
                        y.COM_CommercialInvoice.ItemDescs.ItemDescShortName,
                        y.COM_CommercialInvoice.UnitMaster.UnitShortName,
                        y.COM_CommercialInvoice.Quantity,
                        y.COM_CommercialInvoice.TotalValue
                    })
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetDocumentAcceptanceList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _DocumentAcceptance_MasterRepository.All();
              

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BillOfExchangeRef.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.COM_DocumentAcceptance_Details).Include(x => x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BillOfExchangeRef,
                                BillDate = e.BillDate != null ? e.BillDate.Value.ToString("dd-MMM-yyyy") : null,    
                                e.SupplierInformations.SupplierName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.TotalBBLCAmount,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public JsonResult DeleteDocumentAcceptance(int id)
        {
            try
            {


                var model = _DocumentAcceptance_MasterRepository.Find(id);
                var modelSub = _DocumentAcceptance_DetailsRepository.All().Where(x => x.DocumentAcceptanceMasterId == model.Id).ToList();

                if (model != null)
                {

                    _DocumentAcceptance_DetailsRepository.RemoveRange(modelSub);
                    _DocumentAcceptance_MasterRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        public IActionResult getBBLCDrodpwn()
        {
            var data = _bBLCMainRepository.GetAllForDropDown();
            return Json(data);
        }
        #endregion



        #region work order region
        public IActionResult CreateWorkOrder(int WorkOrderId = 0)
        {

            if (WorkOrderId > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.WorkOrderId = WorkOrderId;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.WorkOrderId = WorkOrderId;
                return View();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveWorkOrder([FromBody] WorkOrderMaster model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        _WorkOrderMasterRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _WorkOrderMasterRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWorkOrder(int id)
        {
            try
            {
                var colorsquery = _WorkOrderMasterRepository.All().Where(x => x.Id == id);

                var color = colorsquery.Include(p => p.CommercialCompany)
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.CommercialCompanyId,
                      p.WorkOrderNo,
                      WorkOrderDate = p.WorkOrderDate != null ? p.WorkOrderDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.SupplierId,
                      p.ToPerson,
                      ServiceContractStartDate= p.ServiceContractStartDate != null ? p.ServiceContractStartDate.Value.ToString("dd-MMM-yyyy") : null,
                      ServiceContractEndDate= p.ServiceContractEndDate != null ? p.ServiceContractEndDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.CurrencyId,
                      p.ConversionRate,
                      p.WorkOrderType,
                      AgreementDate= p.AgreementDate != null ? p.AgreementDate.Value.ToString("dd-MMM-yyyy") : null,
                      DeliveryDate = p.DeliveryDate != null ? p.DeliveryDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.Subject,
                      p.PaymentTerms,
                      p.ShipTo,
                      p.OtherTerms,
                      p.SubTotal,
                      p.RecommenedById,
                      p.SalesTax,
                      p.ApprovedById,
                      p.Shipping,
                      p.OtherExp,
                      p.Total,
                      p.AdvancePayment,
                      p.NetPayable,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = color, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteWorkOrder(int id)
        {
            try
            {


                var model = _WorkOrderMasterRepository.Find(id);

                if (model != null)
                {
                    _WorkOrderMasterRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetWorkOrderList(string fromDate = "", string toDate = "", int supplierid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _WorkOrderMasterRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.WorkOrderNo.ToLower().Contains(searchquery.ToLower())
                    );

                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.CommercialCompany)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                woconcrn=p.CommercialCompany.CompanyName,
                                woWorkorderStatus=p.WorkorderStatus,
                                woWorkOrderNo=p.WorkOrderNo,
                                woWorkOrderDate = p.WorkOrderDate != null ? p.WorkOrderDate.Value.ToString("dd-MMM-yyyy") : null,
                                woSupplierName=p.SupplierInformation.SupplierName,
                                woToPerson=p.ToPerson,
                                woAgreementDate = p.AgreementDate != null ? p.AgreementDate.Value.ToString("dd-MMM-yyyy") : null,
                                woDeliveryDate = p.DeliveryDate != null ? p.DeliveryDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractStartDate = p.ServiceContractStartDate != null ? p.ServiceContractStartDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractEndDate = p.ServiceContractEndDate != null ? p.ServiceContractEndDate.Value.ToString("dd-MMM-yyyy") : null,
                                woCountryShortName=p.Currency.CountryShortName,
                                woConversionRate=p.ConversionRate,
                                woWorkOrderType=p.WorkOrderType,
                                woSubject=p.Subject,
                                woPaymentTerms=p.PaymentTerms,
                                woOtherTerms=p.OtherTerms,
                                woWorkOrderQty=p.WorkOrderQty,
                                woWorkOrderRate=p.WorkOrderRate,
                                woSubTotal=p.SubTotal,
                                woSalesTax=p.SalesTax,
                                woOtherExp=p.OtherExp,
                                woWorkOrderAmt=p.WorkOrderAmt,
                                woAdvancePayment=p.AdvancePayment,
                                woTotal=p.Total,
                                woShipTo=p.ShipTo,
                                woShipping=p.Shipping,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion





        #region doc automation region
        public IActionResult BBLCReport(int backtobacklcid = 0)
        {

            if (backtobacklcid > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getOtherDataForBBLCReport(int BBLCId = 0)
        {
            var data = _bBLCMainRepository.All().Where(x => x.Id == BBLCId)
                .Select(x => new
                {
                    x.Id,
                    x.RefNo,
                    x.Percentage,
                    x.PrintDate,
                }).FirstOrDefault();
            return Json(data);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpsertBBLCRefNo(int BBLCId, string RefNo, string Percentage, string PrintDate)
        {
            var bblcOtherDatas = _bBLCMainRepository.All().Where(a =>a.Id == BBLCId).FirstOrDefault();
            if (bblcOtherDatas != null)
            {
                bblcOtherDatas.RefNo = RefNo;
                bblcOtherDatas.Percentage = Percentage;
                bblcOtherDatas.PrintDate = PrintDate;
                _bBLCMainRepository.Update(bblcOtherDatas, BBLCId);

                return Json(new { error = false, message = "Updated successfully", Id = BBLCId });
            }
            return Json(new { error = false, message = "", Id = BBLCId });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveTruckInfo([FromBody] TruckInfo model)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            try
            {

                if (ModelState.IsValid)
                {

                    if (model.Id > 0)
                    {
                        _TruckInfoRepository.Update(model, model.Id);
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _TruckInfoRepository.Insert(model);
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                return Json(new { error = false, message = "", Id = model.Id });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult getMasterLCData(int groupLCid = 0)
        //{

        //    if (groupLCid > 0)
        //    {
        //        var groupLCDataa = proformaInvoiceRepository.All().Where(x => x.GroupLCId == groupLCid);

        //        var buyerId = groupLCMainRepository.All().Where(x => x.Id == groupLCid).FirstOrDefault().BuyerId;

        //        var sumAmount = groupLCMainRepository.All().Where(x => x.Id == groupLCid && x.Buyers.Id == buyerId).Sum(x => x.TotalGroupLCValue);

        //        var groupLCData = groupLCMainRepository.All().Where(x => x.Id == groupLCid)
        //            .Select(x => new
        //            {
        //                buyerName = x.Buyers.Name,
        //                Benificiary = "Benificiary",
        //                ContactRef = x.GroupLCRefName,
        //                LCDate = x.GroupLC_Sub.FirstOrDefault().MasterLC.LCOpenDate.ToString("dd-MMM-yyyy"),
        //                Amount = x.TotalGroupLCValue

        //            }).ToList();
        //        //var piid = groupLCDataa.FirstOrDefault().Id;


        //        var ComId = HttpContext.Session.GetInt32("ComId");
        //        var UserId = HttpContext.Session.GetInt32("UserId");
        //        var queryname = "getMasterLCData";
        //        var viewquery = $"Exec {queryname} '{ComId}','{groupLCid}','{0}'";
        //        Console.WriteLine(viewquery);
        //        SqlParameter[] parameters = new SqlParameter[3];
        //        parameters[0] = new SqlParameter("@ComId", ComId);
        //        parameters[1] = new SqlParameter("@groupLCid ", groupLCid);
        //        parameters[2] = new SqlParameter("@PIID  ", 0);

        //        var datasetabc = new System.Data.DataSet();
        //        datasetabc = Helper.ExecProcMapDS(queryname, parameters);


        //        var margin = _bBLCMainRepository.All().Where(x => x.GroupLCId == groupLCid).Sum(x => x.Tenor);

        //        return Json(new { data = groupLCData, datasetabc = datasetabc, sumAmount = sumAmount, margin = margin });
        //    }
        //    return Json(new { data = "" });
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult getProformaInvoiceData(int SupplierID = 0)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");
        //    var UserId = HttpContext.Session.GetInt32("UserId");
        //    var queryname = "getProformaInvoiceData";
        //    var viewquery = $"Exec {queryname} '{ComId}','{SupplierID}'";
        //    Console.WriteLine(viewquery);
        //    SqlParameter[] parameters = new SqlParameter[2];
        //    parameters[0] = new SqlParameter("@ComId", ComId);
        //    parameters[1] = new SqlParameter("@SupplierID ", SupplierID);

        //    var datasetabc = new System.Data.DataSet();
        //    datasetabc = Helper.ExecProcMapDS(queryname, parameters);

        //    return Json(new { data = datasetabc, ex = "" });
        //    //var proformaInvoice = proformaInvoiceRepository.All().Where(x=>x.SupplierId== SupplierID)
        //    //    .Select(x => new
        //    //    {
        //    //        piid=x.Id,
        //    //        x.PINo,
        //    //        x.ImportPONo,
        //    //        x.ItemGroups.ItemGroupName,
        //    //        x.ItemDescs.ItemDescName,
        //    //        x.ImportQty,
        //    //        x.ImportRate,
        //    //        x.TotalValue
        //    //    }).ToList();
        //    //return Json(new {data= proformaInvoice });
        //}



        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult SaveBBLC([FromBody] BBLCMain model)
        //{
        //    try
        //    {
        //        var UserId = HttpContext.Session.GetInt32("UserId");
        //        var ComId = HttpContext.Session.GetInt32("ComId");

        //        var errors = ModelState.Where(x => x.Value.Errors.Any())
        //        .Select(x => new { x.Key, x.Value.Errors });


        //        if (ModelState.IsValid)
        //        {
        //            if (model.Id > 0)
        //            {

        //                _bBLCMainRepository.Update(model, model.Id);

        //                var previousitem = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();
        //                var tmp = previousitem.Where(x => !model.BBLC_Details.Any(z => x.Id == z.Id)).ToList();
        //                _bBLCDetailsRepository.RemoveRange(tmp);
        //                foreach (BBLC_Details item in model.BBLC_Details)
        //                {
        //                    if (item.Id > 0)
        //                    {
        //                        item.BBLCMainId = model.Id;
        //                        _bBLCDetailsRepository.Update(item, item.Id);

        //                    }
        //                    else
        //                    {
        //                        item.BBLCMainId = model.Id;
        //                        _bBLCDetailsRepository.Insert(item);

        //                    }
        //                }
        //                TempData["Message"] = "Data Update Successfully";
        //                TempData["Status"] = "2";
        //                return Json(new { error = false, message = "Updated successfully", Id = model.Id });
        //            }
        //            else
        //            {

        //                foreach (var item in model.BBLC_Details.Where(x => x.IsDelete == false))
        //                {

        //                    item.CreateDate = DateTime.Now;
        //                    item.UpdateDate = DateTime.Now;
        //                    item.ComId = int.Parse(ComId.ToString());
        //                    item.LuserId = int.Parse(UserId.ToString());
        //                    item.BBLCMainId = model.Id;
        //                }
        //                _bBLCMainRepository.Insert(model);
        //                TempData["Message"] = "Data Save Successfully";
        //                TempData["Status"] = "1";
        //                return Json(new { error = false, message = "Saved successfully", Id = model.Id });
        //            }
        //        }
        //        else
        //        {

        //            return Json(new { error = true, message = "failed to save" });
        //        }



        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { error = true, message = ex.Message });
        //    }
        //}


        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult getBBLCData(int id = 0)
        //{
        //    var getAllBBLC = _bBLCMainRepository.All().Where(x => x.Id == id);
        //    var query = getAllBBLC.Include(x => x.BBLC_Details)
        //        .Select(x => new
        //        {
        //            x.Id,
        //            x.ComId,
        //            x.BBLCNo,
        //            x.BBLCAmdNo,
        //            x.UDNo,
        //            x.AmdNo,
        //            x.CommercialCompanyId,
        //            x.ShipModeId,
        //            x.GroupLCId,
        //            x.TotalValue,
        //            x.PaymentTerm,
        //            x.PaymentTermsId,
        //            x.DayListId,
        //            x.DecreaseValue,
        //            x.NetValue,
        //            x.GroupLCAverage,
        //            x.DayListTermId,
        //            x.Insurance,
        //            x.CurrencyId,
        //            x.PortOfLoadingId,
        //            x.PortOfDischargeId,
        //            x.Percentage,
        //            x.OpeningBankId,
        //            x.Tenor,
        //            x.LienBankId,
        //            x.TradeTermId,
        //            LcOpeningDate = x.LcOpeningDate != null ? x.LcOpeningDate.Value.ToString("dd-MMM-yyyy") : null,
        //            ExpiryDate = x.ExpiryDate != null ? x.ExpiryDate.Value.ToString("dd-MMM-yyyy") : null,
        //            UDDate = x.UDDate != null ? x.UDDate.Value.ToString("dd-MMM-yyyy") : null,
        //            FirstShipmentDate = x.FirstShipmentDate != null ? x.FirstShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
        //            LastShipmentDate = x.LastShipmentDate != null ? x.LastShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
        //            x.DestinationID,
        //            x.ConvertRate,
        //            x.BBLCValue,
        //            x.BBLCQty,
        //            x.Balance,
        //            x.PrevBBLCValue,
        //            x.IncreaseValue,
        //            x.SupplierId,
        //            x.ItemGroupId,
        //            BBLCDetails = x.BBLC_Details.Select(y => new
        //            {
        //                y.Id,
        //                piid = y.PIId,
        //                PINo = y.COM_ProformaInvoice.PINo,
        //                ImportPONo = y.COM_ProformaInvoice.ImportPONo,
        //                ItemGroupName = y.COM_ProformaInvoice.ItemGroups.ItemGroupName,
        //                ItemDescName = y.COM_ProformaInvoice.ItemDescs.ItemDescName,
        //                ImportQty = y.COM_ProformaInvoice.ImportQty,
        //                ImportRate = y.COM_ProformaInvoice.ImportRate,
        //                TotalValue = y.COM_ProformaInvoice.TotalValue,
        //                y.BBLCMainId,
        //                y.ComId
        //            })
        //        }).FirstOrDefault();
        //    return Json(query);
        //}

        //[AllowAnonymous]
        //public JsonResult BBLCSearch(string query)
        //{
        //    //var UserId = HttpContext.Session.GetInt32("UserId");
        //    //var ComId = HttpContext.Session.GetInt32("ComId");

        //    ////|| (x.BrandName.ToLower().Contains(query.ToLower()))  need to check by fahad
        //    var abc = _bBLCMainRepository.All()
        //        .Where(x => (x.BBLCNo.ToLower().Contains(query.ToLower()))).ToList()
        //                .Select(p => new
        //                {
        //                    Id = p.Id,
        //                    p.BBLCNo,
        //                    p
        //                }).Take(10);

        //    return Json(abc);
        //}


        //[AllowAnonymous]
        //public JsonResult GetBBLCList(string fromDate = "", string toDate = "", int supplierid = 0, int concernid = 0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch = "")
        //{
        //    try
        //    {
        //        var CurrentUserId = HttpContext.Session.GetInt32("UserId");
        //        var ComId = HttpContext.Session.GetInt32("ComId");
        //        var purchaselist = _bBLCMainRepository.All();
        //        if (concernid > 0)
        //        {
        //            purchaselist = _bBLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid);
        //        }
        //        if (supplierid > 0)
        //        {
        //            purchaselist = _bBLCMainRepository.All().Where(x => x.SupplierId == supplierid);
        //        }
        //        if (!string.IsNullOrEmpty(fromDate))
        //        {
        //            DateTime fromDateValue = Convert.ToDateTime(fromDate);
        //            purchaselist = _bBLCMainRepository.All().Where(x => x.LcOpeningDate >= fromDateValue.Date);
        //        }
        //        if (!string.IsNullOrEmpty(toDate))
        //        {
        //            DateTime toDateValue = Convert.ToDateTime(toDate);
        //            purchaselist = _bBLCMainRepository.All().Where(x => x.ExpiryDate >= toDateValue.Date);
        //        }

        //        if (searchquery?.Length > 1)
        //        {
        //            purchaselist = purchaselist.Where(x =>
        //                x.BBLCNo.ToLower().Contains(searchquery.ToLower()) ||
        //                x.BBLCAmdNo.ToLower().Contains(searchquery.ToLower()) ||
        //                x.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo.ToLower().Contains(searchquery.ToLower()) ||
        //                x.SupplierInformation.SupplierName.ToLower().Contains(searchquery.ToLower())
        //            );

        //        }

        //        if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
        //        {
        //            purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(dropdownSearch.ToLower()));
        //        }


        //        decimal TotalRecordCount = purchaselist.Count();
        //        var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
        //        var PageCount = Math.Ceiling(PageCountabc);



        //        decimal skip = (page - 1) * size;
        //        var query = from e in purchaselist.Include(x => x.BBLC_Details).Include(x => x.SupplierInformation).Include(x => x.CompanyList)
        //                    select new
        //                    {
        //                        Id = e.Id,
        //                        e.ComId,
        //                        e.BBLCNo,
        //                        e.BBLCAmdNo,
        //                        e.SupplierId,
        //                        bblcCompanyName = e.CompanyList.CompanyName,
        //                        e.SupplierInformation.SupplierName,
        //                        bblcPINo = e.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo,
        //                    };
        //        var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
        //        var pageinfo = new PagingInfo();
        //        pageinfo.PageCount = int.Parse(PageCount.ToString());
        //        pageinfo.PageNo = page;
        //        pageinfo.PageSize = int.Parse(size.ToString());
        //        pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
        //        return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




        //public JsonResult DeleteBBLC(int id)
        //{
        //    try
        //    {


        //        var model = _bBLCMainRepository.Find(id);
        //        var modelSub = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();

        //        if (model != null)
        //        {

        //            _bBLCDetailsRepository.RemoveRange(modelSub);
        //            _bBLCMainRepository.Delete(model);

        //            return Json(new { success = "1", msg = "Deleted Successfully" });
        //        }
        //        return Json(new { success = "0", msg = "No items found to delete." });

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
        //        throw ex;
        //    }
        //}


        [AllowAnonymous]
        public JsonResult TruckInfoSearch(string query)
        {
            var abc = _TruckInfoRepository.All()
                .Where(x => (x.TruckNo.ToLower().Contains(query.ToLower())) ||
                (x.DriverName.ToLower().Contains(query.ToLower())) ||
                (x.MobileNo.ToLower().Contains(query.ToLower()))
                ).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.TruckNo,
                            p.DriverName,
                            p.MobileNo,
                        }).Take(10);
            return Json(abc);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SetSession(string reporttype, string action, int? reportid, string refno, string printdate, string truckno, string drivername, string drivermobileno, int? grouplcid, string multipleproformainvoice, string Percentage, string multiplemasterlc)
        {
            try
            {
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintBBLCOpen")
                {
                    redirectUrl = Url.Action("COM_BBLC_Master", "Variable", new { id = grouplcid });
                    return Json(new { Url = redirectUrl });
                }
                else
                {
                    redirectUrl = Url.Action("COM_BBLC_Master", "Variable", new { id = reportid });
                    return Json(new { Url = redirectUrl });
                }


                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            //return RedirectToAction("Index");

        }



        [AllowAnonymous]
        public JsonResult GroupLCSearchAutocomplete(string query)
        {
            var abc = groupLCMainRepository.All()
                .Where(x => (x.GroupLCRefName.ToLower().Contains(query.ToLower()))).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.GroupLCRefName,
                        }).Take(10);

            return Json(abc);
        }

        [AllowAnonymous]
        public JsonResult getOtherDataByGroupLCId(int GroupLCID)
        {
            var proformaInvoice = proformaInvoiceRepository.All().Where(x=>x.GroupLCId==GroupLCID)
                        .Select(p => new
                        {
                            p.Id,
                            p.PINo,
                        }).ToList();

            var exportLC = groupLCSubRepository.All().Where(x => x.GroupLCId == GroupLCID && x.MasterLCID!=null)
                .Select(x => new
                {
                    x.Id,
                    exportInvoiceId = x.MasterLC.ExportInvoiceMasters.FirstOrDefault().Id,
                    x.MasterLC.ExportInvoiceMasters.FirstOrDefault().InvoiceNo
                }).ToList();

            return Json(new {proformaInvoice= proformaInvoice, exportLC= exportLC});
        }

        [HttpGet]
        public IActionResult proformaInvoiceDrodpdown()
        {
            var dropdown = proformaInvoiceRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion

    }
}

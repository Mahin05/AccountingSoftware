using Atrai.Core.Entity.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Atrai.Core.Entity.Self;

namespace Atrai.Core.Entity
{
    [Table("Style")]
    public class StyleModel : BaseModel
    {
        [DisplayName("Style No")]

        [StringLength(100)]
        public string StyleNo { get; set; }

        public ICollection<ColorsChildModel> ColorsChilds { get; set; }
        public ICollection<SizesChildModel> SizesChilds { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int BuyerId { get; set; }
        public virtual CustomerModel Buyers { get; set; }
    }

    [Table("ColorChild")]
    public class ColorsChildModel : BaseModel
    {
        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("Style")]
        [ForeignKey("StyleModel")]
        public int StyleId { get; set; }
        public StyleModel StyleModel { get; set; }
    }

    [Table("SizeChild")]
    public class SizesChildModel : BaseModel
    {
        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }

        [DisplayName("Style")]
        [ForeignKey("StyleModel")]
        public int StyleId { get; set; }
        public StyleModel StyleModel { get; set; }
    }

    [Table("BuyerPO_Master")]
    public class BuyerPO_MasterModel : BaseModel
    {
        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel Style { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int? BuyerId { get; set; }
        public virtual CustomerModel Buyers { get; set; }

        public double TotalQuantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }

        [StringLength(200)]
        public string BuyerPO { get; set; }
        public ICollection<BuyerPO_DetailsModel> BuyerPO_Details { get; set; }
    }

    [Table("BuyerPO_Details")]
    public class BuyerPO_DetailsModel : BaseModel
    {
        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel BuyerPO_Master { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }
        public double Quantity { get; set; }
    }

    [Table("BOMAllocationCategory")]
    public class BOMAllocationCategoryModel : BaseModel
    {
        [StringLength(200)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string ShortName { get; set; }


    }

    [Table("BOMMaster")]
    public class BOMMasterModel : BaseModel
    {
        public string BOMCode { get; set; }

        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int StyleId { get; set; }
        public virtual StyleModel Style { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }

        public double LossPercentage { get; set; }
        public ICollection<BOMDetailsModel> BOMDetails { get; set; }
    }

    [Table("BOMDetails")]
    public class BOMDetailsModel : BaseModel
    {
        [StringLength(50)]
        public string Remarks1 { get; set; }

        [StringLength(50)]
        public string Remarks2 { get; set; }

        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel BOMMaster { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }

        public double LossPercentage { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }


    [Table("BuyerPO_Consumption")]
    public class BuyerPO_ConsumptionModel : BaseModel
    {
        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel BuyerPO_Master { get; set; }



        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel BOMMaster { get; set; }

        [StringLength(50)]
        public string Remarks1 { get; set; }

        [StringLength(50)]
        public string Remarks2 { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }

        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

    }

    [Table("MASTERPO_Consumption")]
    public class MASTERPO_ConsumptionModel : BaseModel

    {
        [DisplayName("Master PO")]
        [ForeignKey("MasterPO")]
        public int MasterPOId { get; set; }
        public virtual MasterPOModel MasterPO { get; set; }

        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel BuyerPO_Master { get; set; }

        [DisplayName("BOMMasterId")]
        [ForeignKey("BOMMaster")]
        public int BOMMasterId { get; set; }
        public virtual BOMMasterModel BOMMaster { get; set; }

        [StringLength(50)]
        public string Remarks1 { get; set; }

        [StringLength(50)]
        public string Remarks2 { get; set; }

        [DisplayName("ProductId")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }

        [DisplayName("SupplierId")]
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public virtual SupplierModel Supplier { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }

        [DisplayName("BOMAllocationCategoryId")]
        [ForeignKey("BOMAllocationCategory")]
        public int? BOMAllocationCategoryId { get; set; }
        public virtual BOMAllocationCategoryModel BOMAllocationCategory { get; set; }

        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

    }


    [Table("DailyProduction_Master")]  
    public class DailyProduction_MasterModel : BaseModel 
    {

        [DisplayName("StyleId")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel Style { get; set; }

        [DisplayName("BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int? BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel BuyerPO_Master { get; set; }

        [DisplayName("BuyerId")]
        [ForeignKey("Buyers")]
        public int? BuyerId { get; set; }
        public virtual CustomerModel Buyers { get; set; }

        public double TotalQuantity { get; set; }

        [DisplayName("DepartmentId")]
        [ForeignKey("Departments")]
        public int? DepartmentId { get; set; }
        public virtual Cat_DepartmentModel Departments { get; set; }

        public ICollection<DailyProduction_DetailsModel> DailyProduction_Details { get; set; }
    }

    [Table("DailyProduction_Details")]
    public class DailyProduction_DetailsModel : BaseModel
    {

        [DisplayName("DailyProductionId")]
        [ForeignKey("DailyProduction_Master")]
        public int DailyProductionId { get; set; }
        public virtual DailyProduction_MasterModel DailyProduction_Master { get; set; }

        [DisplayName("ColorId")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel Colors { get; set; }

        [DisplayName("SizeId")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel Sizes { get; set; }
        public double ReceivedQuantity { get; set; }
    }

}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }

            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);

                this.AddRange(items);
            }

            public bool HasPreviousPage => PageIndex > 1;

            public bool HasNextPage => PageIndex < TotalPages;

            public static async Task<PaginatedList<T>> CreateAsync(
                IQueryable<T> source, int pageIndex, int pageSize)
            {
                var count = await source.CountAsync();
                var items = await source.Skip(
                    (pageIndex - 1) * pageSize)
                    .Take(pageSize).ToListAsync();
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
        }
    }
//public int PageIndex { get; private set; }
//    public int TotalPages { get; private set; }

//    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
//    {
//        PageIndex = pageIndex;
//        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

//        this.AddRange(items);
//    }

//    public bool HasPreviousPage
//    {
//        get
//        {
//            return (PageIndex > 1);
//        }
//    }

//    public bool HasNextPage
//    {
//        get
//        {
//            return (PageIndex < TotalPages);
//        }
//    }

//    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
//    {
//        var count = await source.CountAsync();
//        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
//        return new PaginatedList<T>(items, count, pageIndex, pageSize);
//    }
//}
//}


//@page
//@model ID.Models.PackageIndexModel

//@{
//    ViewData["Title"] = "Packages";
//}

//< h2 > Packages </ h2 >

//< p >
//    < a asp - page = "Create" > Create New </ a >
//       </ p >
       

//       < form asp - page = "./Index" method = "get" >
            
//                < div class= "form-actions no-color" >
             
//                     < p >
//                         Find by name:
//            < input type = "text" name = "SearchString" value = "@Model.CurrentFilter" />
     
//                 < input type = "submit" value = "Search" class= "btn btn-primary" /> |
          
//                      < a asp - page = "./Index" > Back to full List</a>
//        </p>
//    </div>
//</form>

//<table class= "table" >
//    < thead >
//        < tr >
//            < th >
//                < a asp - page = "./Index" asp - route - sortOrder = "@Model.NameSort"
//                   asp - route - currentFilter = "@Model.CurrentFilter" >
//                    @Html.DisplayNameFor(model => model.Packages[0].PackageNameId)
//                </ a >
//            </ th >
//            < th >
//                @Html.DisplayNameFor(model => model.Packages[0].PackageDetail)
//            </ th >
//            < th >
//                < a asp - page = "./Index" asp - route - sortOrder = "@Model.TypeSort"
//                   asp - route - currentFilter = "@Model.CurrentFilter" >
//                    @Html.DisplayNameFor(model => model.Packages[0].PackageType)
//                </ a >
//            </ th >
//            < th >
//                @Html.DisplayNameFor(model => model.Packages[0].Supplier)
//            </ th >
//            < th >
//                < a asp - page = "./Index" asp - route - sortOrder = "@Model.PriceSort"
//                   asp - route - currentFilter = "@Model.CurrentFilter" >
//                    @Html.DisplayNameFor(model => model.Packages[0].PackagePrice)
//                </ a >
//            </ th >
//            < th ></ th >
//        </ tr >
//    </ thead >
//    < tbody >
//        @foreach(var item in Model.Packages)
//        {
//        < tr >
//            < td >
//                @Html.DisplayFor(modelItem => item.PackageNameId)
//            </ td >
//            < td >
//                @Html.DisplayFor(modelItem => item.PackageDetail)
//            </ td >
//            < td >
//                @Html.DisplayFor(modelItem => item.PackageType)
//            </ td >
//            < td >
//                @Html.DisplayFor(modelItem => item.Supplier.SupplierName)
//            </ td >
//            < td >
//                @Html.DisplayFor(modelItem => item.PackagePrice)
//            </ td >
//            < td >
//                < img src = "~/images/@item.Pic" class= "rounded-circle" width = "80" height = "80" asp - append - version = "true" />
        
//                    </ td >
        
//                    < td >
        
//                        < a asp - page = "./Edit" asp - route - id = "@item.PackageId" > Edit </ a > |
             
//                             < a asp - page = "./Details" asp - route - id = "@item.PackageId" > Details </ a > |
                  
//                                  < a asp - page = "./Delete" asp - route - id = "@item.PackageId" > Delete </ a >
                       
//                                   </ td >
                       
//                               </ tr >
//        }
//    </ tbody >
//</ table >

//@{
//    var prevDisabled = !Model.Packages.HasPreviousPage ? "disabled" : "";
//    var nextDisabled = !Model.Packages.HasNextPage ? "disabled" : "";
//}

//< a asp - page = "./Index"
//   asp - route - sortOrder = "@Model.CurrentSort"
//   asp - route - pageIndex = "@(Model.Packages.PageIndex - 1)"
//   asp - route - currentFilter = "@Model.CurrentFilter"
//   class= "btn btn-primary @prevDisabled" >
//    Previous
//</ a >
//< a asp - page = "./Index"
//   asp - route - sortOrder = "@Model.CurrentSort"
//   asp - route - pageIndex = "@(Model.Packages.PageIndex + 1)"
//   asp - route - currentFilter = "@Model.CurrentFilter"
//   class= "btn btn-primary @nextDisabled" >
//    Next
//</ a >




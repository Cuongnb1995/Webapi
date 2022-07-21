namespace WebApplication1.Models
{
    public class ViewModelPaging
    {
            public IEnumerable<ViewEmployee> ViewEmployee { get; set; }
            public Pager Pager { get; set; }
    }
}

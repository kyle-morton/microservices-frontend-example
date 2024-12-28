using web_app.Models;

namespace web_app.ViewModels;

public class IndexViewModel
{
    public List<UserPost> Posts { get; set; }

    public IndexViewModel(List<UserPost> posts)
    {
        Posts = posts;
    }
}

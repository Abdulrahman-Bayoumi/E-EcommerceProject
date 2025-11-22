using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Blogs;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Blogs;

namespace Nop.Web.Components;

public partial class HomepageBlogViewComponent : NopViewComponent
{
    protected readonly IBlogModelFactory _blogModelFactory;
    protected readonly BlogSettings _blogSettings;

    public HomepageBlogViewComponent(IBlogModelFactory blogModelFactory, BlogSettings blogSettings)
    {
        _blogModelFactory = blogModelFactory;
        _blogSettings = blogSettings;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!_blogSettings.Enabled)
            return Content("");

        var model = await _blogModelFactory.PrepareBlogPostListModelAsync(new BlogPagingFilteringModel { PageSize = 3 });
        
        if (model.BlogPosts == null || !model.BlogPosts.Any())
            return Content("");

        return View(model);
    }
}


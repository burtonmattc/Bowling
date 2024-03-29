﻿using Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlInfo;
        public PaginationTagHelper(IUrlHelperFactory urlInfo)
        {
            _urlInfo = urlInfo;
        }

        public PageNumberingInfo PageInfo { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        //our own dictionary key value pair
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelp = _urlInfo.GetUrlHelper(ViewContext);
            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);
                individualTag.InnerHtml.AppendHtml(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);

            }
            output.Content.AppendHtml(finishedTag);

        }
    }
}

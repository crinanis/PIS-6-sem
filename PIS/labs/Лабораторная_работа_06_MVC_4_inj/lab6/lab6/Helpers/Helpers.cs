using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString AddPhoneForm(this HtmlHelper helper)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/Dict/AddSave");

            TagBuilder table = new TagBuilder("table");
            TagBuilder tr1 = new TagBuilder("tr");
            TagBuilder td1 = new TagBuilder("td");
            TagBuilder p1 = new TagBuilder("p");
            p1.SetInnerText("Surname: ");
            td1.InnerHtml = p1.ToString();

            TagBuilder td2 = new TagBuilder("td");
            TagBuilder surnameInput = new TagBuilder("input");
            surnameInput.MergeAttribute("type", "text");
            surnameInput.MergeAttribute("name", "surname");
            td2.InnerHtml = surnameInput.ToString();

            tr1.InnerHtml = td1.ToString() + td2.ToString();

            TagBuilder tr2 = new TagBuilder("tr");
            TagBuilder td3 = new TagBuilder("td");
            TagBuilder p2 = new TagBuilder("p");
            p2.SetInnerText("Number: ");
            td3.InnerHtml = p2.ToString();

            TagBuilder td4 = new TagBuilder("td");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("type", "text");
            phoneInput.MergeAttribute("name", "phoneNumber");
            td4.InnerHtml = phoneInput.ToString();

            tr2.InnerHtml = td3.ToString() + td4.ToString();

            TagBuilder tr3 = new TagBuilder("tr");
            TagBuilder td5 = new TagBuilder("td");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Add");
            td5.InnerHtml = submitButton.ToString();
            tr3.InnerHtml = td5.ToString();

            table.InnerHtml = tr1.ToString() + tr2.ToString() + tr3.ToString();
            form.InnerHtml = table.ToString();
            return new MvcHtmlString(form.ToString());
        }

        public static MvcHtmlString UpdatePhoneForm(this HtmlHelper helper)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/Dict/UpdateSave");

            TagBuilder table = new TagBuilder("table");
            TagBuilder tr1 = new TagBuilder("tr");
            TagBuilder td1 = new TagBuilder("td");
            TagBuilder p1 = new TagBuilder("p");
            p1.SetInnerText("Surname: ");
            td1.InnerHtml = p1.ToString();

            TagBuilder td2 = new TagBuilder("td");
            TagBuilder surnameInput = new TagBuilder("input");
            surnameInput.MergeAttribute("type", "text");
            surnameInput.MergeAttribute("name", "surname");
            td2.InnerHtml = surnameInput.ToString();

            tr1.InnerHtml = td1.ToString() + td2.ToString();

            TagBuilder tr2 = new TagBuilder("tr");
            TagBuilder td3 = new TagBuilder("td");
            TagBuilder p2 = new TagBuilder("p");
            p2.SetInnerText("Number: ");
            td3.InnerHtml = p2.ToString();

            TagBuilder td4 = new TagBuilder("td");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("type", "text");
            phoneInput.MergeAttribute("name", "phoneNumber");
            td4.InnerHtml = phoneInput.ToString();

            tr2.InnerHtml = td3.ToString() + td4.ToString();

            TagBuilder tr3 = new TagBuilder("tr");
            TagBuilder td5 = new TagBuilder("td");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Update");
            td5.InnerHtml = submitButton.ToString();
            tr3.InnerHtml = td5.ToString();

            table.InnerHtml = tr1.ToString() + tr2.ToString() + tr3.ToString();
            form.InnerHtml = table.ToString();
            return new MvcHtmlString(form.ToString());
        }

        public static MvcHtmlString DeletePhoneForm(this HtmlHelper helper)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/Dict/DeleteSave");

            TagBuilder table = new TagBuilder("table");
            TagBuilder tr1 = new TagBuilder("tr");
            TagBuilder td1 = new TagBuilder("td");
            TagBuilder p1 = new TagBuilder("p");
            p1.SetInnerText("Surname: ");
            td1.InnerHtml = p1.ToString();

            TagBuilder td2 = new TagBuilder("td");
            TagBuilder surnameInput = new TagBuilder("input");
            surnameInput.MergeAttribute("type", "text");
            surnameInput.MergeAttribute("name", "surname");
            td2.InnerHtml = surnameInput.ToString();

            tr1.InnerHtml = td1.ToString() + td2.ToString();

            TagBuilder tr2 = new TagBuilder("tr");
            TagBuilder td5 = new TagBuilder("td");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Delete");
            td5.InnerHtml = submitButton.ToString();
            tr2.InnerHtml = td5.ToString();

            table.InnerHtml = tr1.ToString() + tr2.ToString();
            form.InnerHtml = table.ToString();
            return new MvcHtmlString(form.ToString());
        }
    }
}

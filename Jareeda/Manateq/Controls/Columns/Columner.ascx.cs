using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Columns
{
    public partial class Columner : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                descLength = 32;
                LoadData();
                int idColumnist = 0;
                string code = Request["cl"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["cl"].ToString();
                }
                Int32.TryParse(code, out idColumnist);
                BusinessLogicLayer.Entities.Persons.Person author = new BusinessLogicLayer.Entities.Persons.Person();
                if (idColumnist != 0)
                {
                    List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.FindArticlesByAuthor(BusinessLogicLayer.Common.DefaultLanguageId, BusinessLogicLayer.Common.ManatiqID.ToString(), idColumnist.ToString());
                    var xlist = (from x in articles orderby x.PostDate descending select x).ToList();
                    int i = 0;
                    author = BusinessLogicLayer.Common.PersonLogic.GetByID(idColumnist);
                    foreach (BusinessLogicLayer.Entities.ContentManagement.Article a in xlist)
                    {
                        BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle cmArticles = new BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle();
                        cmArticles.ArticleID = a.ArticleId;
                        cmArticles.CurrentArticle = a;
                        cmArticles.ArticleOrder = i;
                        cmArticles.HomePageID = HomePageID;
                        Articles.Add(cmArticles);
                        i++;
                    }
                }
                else
                {
                    int id = 0;
                    code = Request["Code"];
                    if (string.IsNullOrEmpty(code))
                    {
                        code = Page.RouteData.Values["Id"].ToString();
                    }
                    Int32.TryParse(code, out id);
                    if (id != 0)
                    {
                        BusinessLogicLayer.Entities.ContentManagement.Article article = BusinessLogicLayer.Common.ArticleLogic.GetByID(id);
                        if (article != null)
                        {
                            author = BusinessLogicLayer.Common.PersonLogic.GetByID(article.AuthorId);
                            List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.FindArticlesByAuthor(BusinessLogicLayer.Common.DefaultLanguageId,BusinessLogicLayer.Common.ManatiqID.ToString(),article.AuthorId.ToString());
                            var xlist = (from x in articles orderby x.PostDate descending select x).ToList();
                            int i = 0;
                            foreach (BusinessLogicLayer.Entities.ContentManagement.Article a in xlist)
                            {
                                BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle cmArticles = new BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle();
                                cmArticles.ArticleID = a.ArticleId;
                                cmArticles.CurrentArticle = a;
                                cmArticles.ArticleOrder = i;
                                cmArticles.HomePageID = HomePageID;
                                Articles.Add(cmArticles);
                                i++;
                            }
                        }
                    }
                }
                if (!author.NewRecord)
                {
                    MainImage.Src = GetWriterImagePath(author.PersonImage);
                    AuthorAlilas.InnerText = author.DisplayName;
                    BusinessLogicLayer.Entities.HumanResources.Employees emp = new BusinessLogicLayer.Components.HumanResources.EmployeesLogic().GetByID(author.BusinessEntityId);
                    if (emp != null)
                        PositionLabel.InnerText = emp.Position;

                }
                ArticlesRepeater.DataSource = Articles;
                ArticlesRepeater.DataBind();
            }

        }
    }
}
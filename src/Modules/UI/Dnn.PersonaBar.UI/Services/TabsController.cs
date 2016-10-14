﻿using System;
using System.Net;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Instrumentation;
namespace Dnn.PersonaBar.UI.Services
{
    [ServiceScope(Scope = ServiceScope.Admin)]
    public class TabsController : PersonaBarApiController
    {
        private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof (TabsController));
        private readonly Library.Controllers.TabsController _controller = new Library.Controllers.TabsController();

        /// GET: api/Tabs/GetPortalTabs
        /// <summary>
        /// Gets list of portal tabs
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="cultureCode"></param>
        /// <param name="isMultiLanguage"></param>
        /// <param name="excludeAdminTabs"></param>
        /// <param name="roles"></param>
        /// <param name="disabledNotSelectable"></param>
        /// <param name="sortOrder"></param>
        /// <param name="selectedTabId">Currently Selected tab id</param>
        /// <returns>List of portal tabs</returns>
        [HttpGet]
        public HttpResponseMessage GetPortalTabs(int portalId, string cultureCode, bool isMultiLanguage = false,
            bool excludeAdminTabs = true, string roles = "", bool disabledNotSelectable = false, int sortOrder = 0, int selectedTabId = -1)
        {
            try
            {
                var response = new
                {
                    Success = true,
                    Results =
                        _controller.GetPortalTabs(portalId, cultureCode, isMultiLanguage, excludeAdminTabs, roles,
                            disabledNotSelectable, sortOrder, selectedTabId)
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="portalId"></param>
        /// <param name="roles"></param>
        /// <param name="disabledNotSelectable"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SearchPortalTabs(string searchText, int portalId, string roles = "", bool disabledNotSelectable = false, int sortOrder = 0)
        {
            try
            {
                var response = new
                {
                    Success = true,
                    Results =
                        _controller.SearchPortalTabs(searchText, portalId, roles, disabledNotSelectable, sortOrder)
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        /// GET: api/Tabs/GetPortalTab
        /// <summary>
        /// Gets list of portal tabs
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="tabId"></param>
        /// <param name="cultureCode"></param>
        /// <returns>List of portal tabs</returns>
        [HttpGet]
        public HttpResponseMessage GetPortalTab(int portalId, int tabId, string cultureCode)
        {
            try
            {
                var response = new
                {
                    Success = true,
                    Results = _controller.GetTabByCulture(tabId, portalId, cultureCode)
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="parentId"></param>
        /// <param name="cultureCode"></param>
        /// <param name="isMultiLanguage"></param>
        /// <param name="roles"></param>
        /// <param name="disabledNotSelectable"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTabsDescendants(int portalId, int parentId, string cultureCode,
            bool isMultiLanguage = false, string roles = "", bool disabledNotSelectable = false, int sortOrder = 0)
        {
            try
            {
                var response = new
                {
                    Success = true,
                    Results =
                        _controller.GetTabsDescendants(portalId, parentId, cultureCode, isMultiLanguage, roles,
                            disabledNotSelectable, sortOrder)
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}
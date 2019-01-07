using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace Seldino.CrossCutting.Web.Views
{
    public class ThemeEngine : VirtualPathProviderViewEngine
    {
        private const string CacheKeyFormat = ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}:{5}";
        private const string CacheKeyPrefixMaster = "Master";
        private const string CacheKeyPrefixPartial = "Partial";
        private const string CacheKeyPrefixView = "View";
        private static readonly string[] EmptyLocations = new string[0];

        public ThemeEngine()
        {
            AreaViewLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{3}/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{3}/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Themes/{3}/Areas/Cms/Views/Shared/PageTemplates/{0}.cshtml",

                //  Default
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            AreaMasterLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{3}/Areas/Cms/Views/Shared/LayoutTemplates/{0}.cshtml",
                "~/Themes/{3}/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{3}/Areas/{2}/Views/Shared/{0}.cshtml",

                //  Default
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            AreaPartialViewLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{3}/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{3}/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Themes/{3}/Areas/{2}/Views/Shared/ModuleTemplates/{0}.cshtml",

                //  Default
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/Cms/Views/Shared/ModuleTemplates/{0}.cshtml"
            };

            ViewLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{2}/Views/Shared/{0}.cshtml",

                //  Default
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            MasterLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{2}/Areas/Cms/Views/Shared/LayoutTemplates/{0}.cshtml",
                "~/Themes/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{2}/Views/Shared/{0}.cshtml",

                //  Default
                "~/Areas/Cms/Views/Shared/LayoutTemplates/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = new[]
            {
                //  Themes
                "~/Themes/{2}/Views/{1}/{0}.cshtml",
                "~/Themes/{2}/Views/Shared/{0}.cshtml",
                "~/Themes/{2}/Areas/Cms/Views/Shared/ModuleTemplates/{0}.cshtml",

                //  Default
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Areas/Cms/Views/Shared/ModuleTemplates/{0}.cshtml"
            };

            FileExtensions = new[] { "cshtml" };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException(nameof(controllerContext));
            }

            if (string.IsNullOrEmpty(viewName))
            {
                throw new ArgumentNullException(nameof(viewName));
            }

            string[] viewLocationsSearched;
            string[] masterLocationsSearched;

            var theme = GetCurrentTheme();

            string controllerName = controllerContext.RouteData.GetRequiredString("controller");

            string viewPath = GetPath(controllerContext,
                ViewLocationFormats,
                AreaViewLocationFormats,
                "ViewLocationFormats",
                viewName,
                controllerName,
                theme,
                CacheKeyPrefixView,
                useCache,
                out viewLocationsSearched);

            string masterPath = GetPath(controllerContext,
                MasterLocationFormats,
                AreaMasterLocationFormats,
                "MasterLocationFormats",
                masterName,
                controllerName,
                theme,
                CacheKeyPrefixMaster,
                useCache,
                out masterLocationsSearched);

            if (string.IsNullOrEmpty(viewPath) || (string.IsNullOrEmpty(masterPath) && !string.IsNullOrEmpty(masterName)))
            {
                return new ViewEngineResult(viewLocationsSearched.Union(masterLocationsSearched));
            }

            return new ViewEngineResult(CreateView(controllerContext, viewPath, masterPath), this);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException(nameof(controllerContext));
            }
            if (string.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentNullException(nameof(partialViewName));
            }

            string[] searched;

            var theme = GetCurrentTheme();

            string controllerName = controllerContext.RouteData.GetRequiredString("controller");

            string partialPath = GetPath(controllerContext, PartialViewLocationFormats, AreaPartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, controllerName, theme, CacheKeyPrefixPartial, useCache, out searched);

            if (string.IsNullOrEmpty(partialPath))
            {
                return new ViewEngineResult(searched);
            }

            return new ViewEngineResult(CreatePartialView(controllerContext, partialPath), this);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new RazorView(controllerContext, partialPath, null, false, FileExtensions);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new RazorView(controllerContext, viewPath, masterPath, true, FileExtensions);
        }

        private static string GetCurrentTheme()
        {
            //var settingContract = DependencyManager.Resolve<IThemeContract>();

            //var getThemeEngineRequiredDataResponse = settingContract.GetThemeEngineRequiredData(new GetThemeEngineRequiredDataRequest());

            //if (!getThemeEngineRequiredDataResponse.IsSucceed)
            //{
            //    return string.Empty;
            //}

            //var webHelper = DependencyManager.Resolve<IWebHelper>();

            //if (!webHelper.IsUserAuthenticated())
            //{
            //    return getThemeEngineRequiredDataResponse.ViewModel.CurrentThemeSystemName;
            //}

            //switch (webHelper.GetUserType())
            //{
            //    case UserType.Visitor:
            //    case UserType.Unregistered:
            //        return getThemeEngineRequiredDataResponse.ViewModel.CurrentThemeSystemName;

            //    case UserType.Admin:
            //        if (getThemeEngineRequiredDataResponse.ViewModel.AdminUserIds == null)
            //        {
            //            return getThemeEngineRequiredDataResponse.ViewModel.CurrentThemeSystemName;
            //        }

            //        bool isAdmin = getThemeEngineRequiredDataResponse.ViewModel.AdminUserIds != null &&
            //               getThemeEngineRequiredDataResponse.ViewModel.AdminUserIds.Select(model => model.AdminUserIds)
            //                   .Contains(webHelper.GetCurrentUserId());

            //        if (!isAdmin)
            //        {
            //            return getThemeEngineRequiredDataResponse.ViewModel.CurrentThemeSystemName;
            //        }

            //        return getThemeEngineRequiredDataResponse.ViewModel.PreviewThemeSystemName;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            return null;
        }

        private static string GetAreaName(RouteData routeData)
        {
            object result;

            if (routeData.DataTokens.TryGetValue("area", out result))
            {
                return result as string;
            }

            return GetAreaName(routeData.Route);
        }

        private static string GetAreaName(RouteBase route)
        {
            var area = route as IRouteWithArea;

            if (area != null)
            {
                return area.Area;
            }

            var route2 = route as Route;

            return route2?.DataTokens?["area"] as string;
        }

        private static List<ViewLocation> GetViewLocations(string[] viewLocationFormats, string[] areaViewLocationFormats)
        {
            var allLocations = new List<ViewLocation>();

            if (areaViewLocationFormats != null)
            {
                foreach (string areaViewLocationFormat in areaViewLocationFormats)
                {
                    allLocations.Add(new AreaAwareViewLocation(areaViewLocationFormat));
                }
            }

            if (viewLocationFormats != null)
            {
                foreach (string viewLocationFormat in viewLocationFormats)
                {
                    allLocations.Add(new ViewLocation(viewLocationFormat));
                }
            }

            return allLocations;
        }

        private static bool IsSpecificPath(string name)
        {
            char character = name[0];

            return character == '~' || character == '/';
        }

        private string CreateCacheKey(string prefix, string name, string controllerName, string areaName, string theme)
        {
            return string.Format(CultureInfo.InvariantCulture, CacheKeyFormat, GetType().AssemblyQualifiedName, prefix, name, controllerName, areaName, theme);
        }

        private static string AppendDisplayModeToCacheKey(string cacheKey, string displayMode)
        {
            return cacheKey + displayMode + ":";
        }

        private static string GetExtensionThunk(string virtualPath)
        {
            return VirtualPathUtility.GetExtension(virtualPath);
        }

        private bool FilePathIsSupported(string virtualPath)
        {
            if (FileExtensions == null)
            {
                // legacy behavior for custom ViewEngine that might not set the FileExtensions property
                return true;
            }

            // get rid of the '.' because the FileExtensions property expects extensions withouth a dot.
            string extension = GetExtensionThunk(virtualPath).TrimStart('.');

            return FileExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private string GetPath(ControllerContext controllerContext, string[] locations, string[] areaLocations, string locationsPropertyName, string name, string controllerName, string theme, string cacheKeyPrefix, bool useCache, out string[] searchedLocations)
        {
            searchedLocations = EmptyLocations;

            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            string areaName = GetAreaName(controllerContext.RouteData);

            bool usingAreas = !string.IsNullOrEmpty(areaName);

            var viewLocations = GetViewLocations(locations, usingAreas ? areaLocations : null);

            if (!viewLocations.Any())
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Properties cannot be null or empty - {0}", locationsPropertyName));
            }

            bool nameRepresentsPath = IsSpecificPath(name);

            string cacheKey = CreateCacheKey(cacheKeyPrefix, name, nameRepresentsPath ? string.Empty : controllerName, areaName, theme);

            if (useCache)
            {
                // Only look at cached display modes that can handle the context.
                IEnumerable<IDisplayMode> possibleDisplayModes = DisplayModeProvider.GetAvailableDisplayModesForContext(controllerContext.HttpContext, controllerContext.DisplayMode);

                foreach (IDisplayMode displayMode in possibleDisplayModes)
                {
                    string cachedLocation = ViewLocationCache.GetViewLocation(controllerContext.HttpContext, AppendDisplayModeToCacheKey(cacheKey, displayMode.DisplayModeId));

                    if (cachedLocation == null)
                    {
                        // If any matching display mode location is not in the cache, fall back to the uncached behavior, which will repopulate all of our caches.
                        return null;
                    }

                    // A non-empty cachedLocation indicates that we have a matching file on disk. Return that result.
                    if (cachedLocation.Length > 0)
                    {
                        if (controllerContext.DisplayMode == null)
                        {
                            controllerContext.DisplayMode = displayMode;
                        }

                        return cachedLocation;
                    }

                    // An empty cachedLocation value indicates that we don't have a matching file on disk. Keep going down the list of possible display modes.
                }

                // GetPath is called again without using the cache.
                return null;
            }

            return nameRepresentsPath ? GetPathFromSpecificName(controllerContext, name, cacheKey, ref searchedLocations) : GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, cacheKey, ref searchedLocations);
        }

        protected virtual string GetPathFromGeneralName(ControllerContext controllerContext, List<ViewLocation> locations, string name, string controllerName, string areaName, string theme, string cacheKey, ref string[] searchedLocations)
        {
            string result = string.Empty;

            searchedLocations = new string[locations.Count];

            for (int index = 0; index < locations.Count; index++)
            {
                var location = locations[index];

                string virtualPath = location.Format(name, controllerName, areaName, theme);

                var virtualPathDisplayInfo = DisplayModeProvider.GetDisplayInfoForVirtualPath(virtualPath, controllerContext.HttpContext, path => FileExists(controllerContext, path), controllerContext.DisplayMode);

                if (virtualPathDisplayInfo != null)
                {
                    string resolvedVirtualPath = virtualPathDisplayInfo.FilePath;

                    searchedLocations = EmptyLocations;

                    result = resolvedVirtualPath;

                    ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, AppendDisplayModeToCacheKey(cacheKey, virtualPathDisplayInfo.DisplayMode.DisplayModeId), result);

                    if (controllerContext.DisplayMode == null)
                    {
                        controllerContext.DisplayMode = virtualPathDisplayInfo.DisplayMode;
                    }

                    // Populate the cache for all other display modes. We want to cache both file system hits and misses so that we can distinguish
                    // in future requests whether a file's status was evicted from the cache (null value) or if the file doesn't exist (empty string).
                    IEnumerable<IDisplayMode> allDisplayModes = DisplayModeProvider.Modes;

                    foreach (var displayMode in allDisplayModes)
                    {
                        if (displayMode.DisplayModeId != virtualPathDisplayInfo.DisplayMode.DisplayModeId)
                        {
                            var displayInfoToCache = displayMode.GetDisplayInfo(controllerContext.HttpContext, virtualPath, virtualPathExists: path => FileExists(controllerContext, path));

                            string cacheValue = string.Empty;

                            if (displayInfoToCache?.FilePath != null)
                            {
                                cacheValue = displayInfoToCache.FilePath;
                            }

                            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, AppendDisplayModeToCacheKey(cacheKey, displayMode.DisplayModeId), cacheValue);
                        }
                    }

                    break;
                }

                searchedLocations[index] = virtualPath;
            }

            return result;
        }

        protected virtual string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, ref string[] searchedLocations)
        {
            string result = name;

            if (!(FilePathIsSupported(name) && FileExists(controllerContext, name)))
            {
                result = string.Empty;
                searchedLocations = new[] { name };
            }

            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, result);
            return result;
        }

        #region Nested classes

        public class AreaAwareViewLocation : ViewLocation
        {
            public AreaAwareViewLocation(string virtualPathFormatString) : base(virtualPathFormatString)
            {
            }

            public override string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, areaName, theme);
            }
        }

        public class ViewLocation
        {
            protected readonly string _virtualPathFormatString;

            public ViewLocation(string virtualPathFormatString)
            {
                _virtualPathFormatString = virtualPathFormatString;
            }

            public virtual string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, theme);
            }
        }

        #endregion
    }
}
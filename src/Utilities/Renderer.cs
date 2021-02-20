﻿namespace ChuckDeviceController.Utilities
{
    using HandlebarsDotNet;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class Renderer
    {
        public static string ViewsDirectory => Path.Combine
        (
            Directory.GetCurrentDirectory(),
            Strings.ViewsFolder
        );

        private static readonly Dictionary<string, string> _templates;

        static Renderer()
        {
            _templates = new Dictionary<string, string>();

            RegisterAllTemplates();
        }

        public static string ParseTemplate(string name, dynamic model)
        {
            if (!_templates.ContainsKey(name))
            {
                Console.WriteLine($"Template is not registered {name}");
                return null;
            }
            return Parse(_templates[name], model);
        }

        public static string Parse(string text, dynamic model)
        {
            HandlebarsTemplate<object, object> template = Handlebars.Compile(text);
            return template(model);
        }

        private static void RegisterAllTemplates()
        {
            foreach (string file in Directory.GetFiles(ViewsDirectory, "*" + Strings.TemplateExt))
            {
                string viewName = Path.GetFileNameWithoutExtension(file);
                string viewData = File.ReadAllText(file);
                Handlebars.RegisterTemplate(viewName, viewData);
                if (!_templates.ContainsKey(viewName))
                {
                    _templates.Add(viewName, viewData);
                }
            }
        }

        public static string GetView(string name)
        {
            string viewPath = Path.Combine(ViewsDirectory, name + Strings.TemplateExt);
            if (!File.Exists(viewPath))
            {
                Console.WriteLine($"View does not exist at {viewPath}");
                return null;
            }
            //return await File.ReadAllTextAsync(viewPath);
            return File.ReadAllText(viewPath);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public static class KeyPressedEventHandlerFactory
    {
        private static readonly List<IKeyPressedOnQuestionDisplayControlEventHandler> _keyPressedEventHandlers;

        static KeyPressedEventHandlerFactory()
        {
            _keyPressedEventHandlers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsAbstract == false && t.GetInterface(nameof(IKeyPressedOnQuestionDisplayControlEventHandler)) != null)
                .Select(t => (IKeyPressedOnQuestionDisplayControlEventHandler)Activator.CreateInstance(t)!)
                .ToList();
        }

        public static IKeyPressedOnQuestionDisplayControlEventHandler? GetProperHandler()
        {
            return _keyPressedEventHandlers.FirstOrDefault(x => x.IsKeyPressed());
        }
    }
}

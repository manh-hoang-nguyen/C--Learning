using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Interfaces;
using UI.Assets.AbstractClasses;
using Interfaces.EventArgument;
using Interfaces.Model.Classes.ConfigureatonItem;
using Interfaces.Model.Interfaces.ConfigureatonItem;
using UI.ViewModel.ConfigureatonItem;

namespace UI.Assets.Helpers
{
	internal static class ViewModelHelpers
	{
		public static UiViewModelBase ViewModel(this ChangeDisplayEventArgs changeDisplayEventArgs)
		{
			UiViewModelBase viewModel;
			var viewModelInterface = changeDisplayEventArgs.ViewModelInterface;
			var dictionary = ChangeDisplayEventArgs.InterfaceTypeDictionary;

			if (changeDisplayEventArgs.CreateNew)
			{
				viewModel = CreateViewModel(changeDisplayEventArgs, dictionary, viewModelInterface);
			}
			else if (ClassLocator.ContainsCreated(changeDisplayEventArgs.ViewModelInterface))
			{
				viewModel = (UiViewModelBase)ClassLocator.GetInstance(changeDisplayEventArgs.ViewModelInterface);
			}
			else
			{
				viewModel = CreateViewModel(changeDisplayEventArgs, dictionary, viewModelInterface);
				ClassLocator.Register(() => viewModel);
			}
			return viewModel;
		}

		private static UiViewModelBase CreateViewModel(ChangeDisplayEventArgs changeDisplayEventArgs, Dictionary<Type, Type> dictionary,
			Type viewModelInterface)
		{
			UiViewModelBase viewModel;
			if (dictionary.ContainsKey(viewModelInterface))
			{
				viewModel = (UiViewModelBase)Activator.CreateInstance(dictionary[changeDisplayEventArgs.ViewModelInterface]);
				viewModel.DisposeOfAfterUse = changeDisplayEventArgs.CreateNew;
			}
			else
			{
				var names = Assembly.GetExecutingAssembly().GetTypes().Select(i => i.Name);

#if DEBUG
				var countOfClasses = GetDerivedForInterfaceType(viewModelInterface).Count();
				if (countOfClasses == 0)
					throw new Exception($"Could not find a class that is derived from the interface {viewModelInterface.Name}");
				else if (countOfClasses > 1)
				{
					var classes = string.Join(", ", GetDerivedForInterfaceType(viewModelInterface).Select(i => i.Name));
					throw new Exception($"Multiple classes found  derived from the interface {viewModelInterface.Name}: {classes}");
				}
#endif

				var displayViewModelClass = GetDerivedForInterfaceType(viewModelInterface).FirstOrDefault();

				viewModel = (UiViewModelBase)Activator.CreateInstance(displayViewModelClass);
				ChangeDisplayEventArgs.InterfaceTypeDictionary.Add(viewModelInterface, displayViewModelClass);
				viewModel.DisposeOfAfterUse = changeDisplayEventArgs.CreateNew;
			}
			return viewModel;
		}

		private static Dictionary<Type, Type> configurationItemViewModelDictionary = new Dictionary<Type, Type>();

		public static IConfigurationItemViewModel GetConfigurationItemViewModel(ConfigurationItemModel model)
		{
			Type genericViewModel;
			if (configurationItemViewModelDictionary.ContainsKey(model.GetType()))
			{
				genericViewModel = configurationItemViewModelDictionary[model.GetType()];
			}
			else
			{
				//				var modelInterfaces = model.GetType().GetInterfaces();
				//				var viewModels = GetDerivedForInterfaceType(typeof(IConfigurationItemViewModel));
				//				var genericViewModels = viewModels.Where(i => i.IsGenericType);
				//				genericViewModel = genericViewModels.Where(i => modelInterfaces.Any(j => i.GetGenericTypeDefinition() == j)).FirstOrDefault();
				//#if DEBUG
				//				if (viewModels.Count() != genericViewModels.Count())
				//				{
				//					var classes = string.Join(", ", viewModels.Select(i => i.Name));
				//					throw new Exception($"One of thses classes is derive from IConfigurationItemViewModel and is not Generic: {classes}");
				//				}
				//				if (genericViewModel == null)
				//					throw new Exception($"Did not find a ConfigurationItemViewModel generic class with generic type definition {model.GetType().Name}");
				//#endif
				if (model is IDisplayOnlyConfigurationItemModel) genericViewModel = typeof(DisplayOnlyConfigurationItemViewModel);
				else if (model is IComboBoxConfigurationItemModel) genericViewModel = typeof(ComboBoxConfigurationItemViewModel);
				else
					throw new Exception($"Did not find a ConfigurationItemViewModel generic class for generic type definition {model.GetType().Name}");
			}

			var viewModel = (IConfigurationItemViewModel)Activator.CreateInstance(genericViewModel);
			MethodInfo setModelMethod = genericViewModel.GetMethod("SetModel");
			setModelMethod.Invoke(viewModel, new[] { model });
			return viewModel;
		}

		private static IEnumerable<Type> GetDerivedForInterfaceType(Type interfaceType)
		{
			return Assembly.GetExecutingAssembly().GetTypes()
					.Where(i => i.IsClass && i.GetInterfaces().Contains(interfaceType));
		}
	}
}

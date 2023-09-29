using IPhoneDictionary;
using DictionaryDB;
using Ninject.Modules;
using System.IO;
using System;
using Ninject.Web.Common;

namespace lab6.Config
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary.IPhoneDictionary>().To<DictionaryJSON.PhoneRepository>().InSingletonScope().WithConstructorArgument("dataFilePath", "d:\\1POIT\\3\\PIS\\labs\\Лабораторная_работа_06_MVC_4_inj\\lab6\\lab6\\App_Data\\phones.json");

            //Bind<IPhoneDictionary.IPhoneDictionary>().To<DictionaryDB.PhoneRepository>().InRequestScope().WithConstructorArgument("context", new PhoneContext());
        }//intransient(требование),insingleton,inthread
    }
}
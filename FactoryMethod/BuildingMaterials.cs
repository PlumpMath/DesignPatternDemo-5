using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod
{
    public abstract class BuildingMaterialsStoreBase
    {
        public void ShowPrice()
        {
            var buildingMaterials = GetBuildingMaterials();
            Console.WriteLine(buildingMaterials.Name + " is " + buildingMaterials.Price);
        }

        protected abstract IBuildingMaterials GetBuildingMaterials();
    }

    public class TimberStore : BuildingMaterialsStoreBase
    {
        protected override IBuildingMaterials GetBuildingMaterials()
        {
            return new Timber();
        }
    }

    public class CementStore : BuildingMaterialsStoreBase
    {
        protected override IBuildingMaterials GetBuildingMaterials()
        {
            return new Cement();
        }
    }

    public interface IBuildingMaterials
    {
         string Name { get;  }
         double Price { get; }
    }

    public class Timber : IBuildingMaterials
    {
        public  string Name
        {
            get { return "Timber"; }
        }

        public  double Price
        {
            get { return 22; }
        }
    }

    public partial class Cement : IBuildingMaterials
    {
        public string Name {
            get { return "Cement"; }
        }
        public double Price {
            get { return 30; }
        }
    }
}

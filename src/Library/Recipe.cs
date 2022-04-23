//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
            /// <summary>
        /// **Agregar la responsabilidad de calcular el costo total de producir un producto final**
        /// **¿Qué patrón o principio usan para asignar esta responsabilidad?**
        /// El patrón utilizado es el Expert. Para realizar la responsabilidad de calcular el costo total 
        /// de producir un producto final es necesario conocer todos los datos necesario, por lo que debe tener 
        /// la capacidad de acceder a clases como Step, Equipment y Product. La clase Recipe es experta 
        /// manejando toda la información necesaria, por lo que se le designa la responsabilidad.
        /// </summary>

        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            double TotalCost = GetProductionCost();
            Console.WriteLine($"El costo total de producción es de {TotalCost}");
        }

        public double GetProductionCost()
        {
            double InputCost = 0;
            double EquipmentCost = 0;

            foreach (Step step in this.steps)
            {
                InputCost += (step.Input.UnitCost * step.Quantity);
                EquipmentCost += (step.Equipment.HourlyCost * step.Time);
            } 
            double TotalCost = InputCost + EquipmentCost;

            return TotalCost;
        }
    }
}
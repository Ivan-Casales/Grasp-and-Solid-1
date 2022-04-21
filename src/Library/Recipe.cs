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
        // Se decidio asignar la responsabilidad de calcular el costo total a la clase Recipe. Dicha desición
        // se baso en el principio Expert, ya que Recipe es la ideal para realizar el método, posee el conocimiento
        // de todos los datos necesarios para calcular el total, por lo tanto se convierte en la misma en el experto 
        // de conocimientos de todos los datos de la Receta, la cual es capaz de acceder a los distintos atributos 
        // de las demas clase como Step, Equipment y Product.

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
                InputCost += step.Input.UnitCost;
                EquipmentCost += (step.Equipment.HourlyCost * step.Time);
            } 
            double TotalCost = InputCost + EquipmentCost;

            return TotalCost;
        }
    }
}
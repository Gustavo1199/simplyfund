using AutoMapper;
using NCalc;
using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Common
{
    public class ServicesExpenses : IServicesExpenses
    {
        IBaseDatas<Expense> baseDatas;
        IMapper mapper;
        public ServicesExpenses(IBaseDatas<Expense> baseDatas, IMapper mapper)
        {
            this.baseDatas = baseDatas;
            this.mapper = mapper;
        }


        public async Task<ExpensesModelsLists> getAuthomaticExpenses(ConditionRequest model)
        {
            try
            {
                var getConditions = await this.baseDatas.GetAsync();

                var conditionsMapped = this.mapper.Map<List<ExpenseDto>>(getConditions);
                var reglasQueAplican = ObtenerReglasQueAplican(conditionsMapped, model);


                return reglasQueAplican;
            }
            catch (Exception)
            {
                throw;
            }
        }



        private  ExpensesModelsLists ObtenerReglasQueAplican(List<ExpenseDto> reglas, ConditionRequest solicitud)
        {
            ExpensesModelsLists expensesConditions = new ExpensesModelsLists();


            //var automaticCondition = reglas

            var automaticExpenses = reglas.Where(regla => EvaluarAutomaticCondicion(regla.Condition, solicitud) && regla.BadgeId == solicitud.CurrencyId).ToList();
            var eligibleExpenses = reglas.Where(regla => EvaluarElegibleCondicion(regla.Condition, solicitud) && regla.BadgeId == solicitud.CurrencyId).ToList();

            expensesConditions.AutomaticsExpense.AddRange(automaticExpenses);
            expensesConditions.ElegibleExpense.AddRange(eligibleExpenses);
            return expensesConditions;

        }

        private  bool EvaluarAutomaticCondicion(string condicion, ConditionRequest solicitud)
        {
            try
            {
                string formattedCondition = formattedConditions(condicion);
                Expression expression = new Expression(formattedCondition);

                expression.Parameters["monto"] = solicitud.Amount;
                expression.Parameters["garantia"] = solicitud.Warranty;
                expression.Parameters["periodo"] = solicitud.Period;
                expression.Parameters["cuotas"] = solicitud.Installments;
                expression.Parameters["elegible"] = "";
                //expression.Parameters["impuesto"] = solicitud.Impuesto;

                var preuab = (bool)expression.Evaluate();

                return preuab;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al evaluar la condición: {ex.Message}");
                return false;
            }
        }



        private  bool EvaluarElegibleCondicion(string condicion, ConditionRequest solicitud)
        {
            try
            {
                string formattedCondition = formattedConditions(condicion);

                if (formattedCondition.Replace(" ", "") == "elegible")
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al evaluar la condición: {ex.Message}");
                return false;
            }
        }

        private  string formattedConditions(string condicion)
        {
            string formattedCondition = condicion.Replace("\"", "'");
            formattedCondition = Regex.Replace(formattedCondition, @"\[([^\]]+)\]", "[$1]");
            formattedCondition = formattedCondition.Replace("&", "&&");
            return formattedCondition;
        }
    }
}

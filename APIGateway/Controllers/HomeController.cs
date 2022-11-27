using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using APIGateway.Models;

namespace APIGateway.Controllers
{
    public class HomeController : Controller
    {
        private readonly CaseStudy _caseStudy;

        public HomeController()
        {
            _caseStudy = new CaseStudy(new PrefilledAgentHub());
        }

        public async Task<ActionResult> Index() => 
            await Task.Run(View);

        public async Task<ActionResult> BankAgents() =>
            await Task
                .Run(async () => ViewData["banks"] = (await _caseStudy.AllBanks()).ToList())
                .ContinueWith(View);

        public async Task<ActionResult> ShopAgents() =>
            await Task
                .Run(async () => ViewData["shops"] = (await _caseStudy.AllShops()).ToList())
                .ContinueWith(View);

        public async Task<ActionResult> CaseStudy() =>
            await Task
                .Run(() => ViewData["caseStudy"] = _caseStudy)
                .ContinueWith(View);

        public async Task<ActionResult> BankVisualizer(string bank)
        {
            return await await Task
                    .Run(async () => (
                        bank: (BankAgent) await _caseStudy.Agent(bank), 
                        table: await _caseStudy.BankTable(bank)))
                    .ContinueWith(async t =>
                    {
                        var tuple = await t;
                        ViewData["table"] = tuple.table;
                        return tuple.bank;
                    })
                .ContinueWith(async b =>
                    {
                        try
                        {
                            return View(await await b);
                        }
                        catch (Exception e)
                        {
                            return View("ErrorView", e);
                        }
                    });
        }

        public async Task<ActionResult> ShopVisualizer(string shop)
        {
            return await await Task
                .Run(async () => (
                    bank: (ShopAgent) await _caseStudy.Agent(shop), 
                    list: await _caseStudy.Products(shop)))
                .ContinueWith(async t =>
                {
                    var tuple = await t;
                    ViewData["list"] = tuple.list;
                    return tuple.bank;
                })
                .ContinueWith(async s =>
                {
                    try
                    {
                        return View(await await s);
                    }
                    catch (Exception e)
                    {
                        return View("ErrorView", e);
                    }
                });
        }
        
        public async Task<ActionResult> ErrorView(Exception exception) => 
            await Task.Run(() => View(exception));

        public async Task<ActionResult> AllBanks() =>
            await Task
                .Run(async () =>
                {
                    var banks =  await _caseStudy.AllBanks();
                    ViewData["resultList"] = string.Join("\n", banks.Select(b => b.Name));
                })
                .ContinueWith(_ => View("CaseStudy"));


        public async Task<ActionResult> AllShops() => 
            await Task
                .Run(async () =>
                {
                    var shops =  await _caseStudy.AllShops();
                    ViewData["resultList"] = string.Join("\n", shops.Select(s => s.Name));
                })
                .ContinueWith(_ => View("CaseStudy"));
    }
}
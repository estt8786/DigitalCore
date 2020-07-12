using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalCore.Data;
using DigitalCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DigitalCore.Controllers
{
    /// <summary>
    /// Alteração do Controller p/ Gerir como vão ser apresentados os Produtos em Categorias
    /// </summary>
    public class ProdutosController : Controller
    {
        /// <summary>
        /// este atributo representa uma referência à nossa BD - Base Dados
        /// </summary>
        //private readonly DigitalCoreDB _context;
        private readonly DigitalCoreDB db;

        /// <summary>
        /// atributo que recolhe nele os dados do Servidor
        /// </summary>
        private readonly IWebHostEnviromment _caminho;

        //public ProdutosController(DigitalCoreDB context)
        public ProdutosController(DigitalCoreDB context, IWebHostEnvironment caminho)

        {

            //_context = context;
            this.db = context;
            this._caminho = caminho;
        }

        // --------------------------- 05-07-2020

        // GET: Produtos

        //public async Task<IActionResult> Index()
        public IActionResult Index()

        {
            // LINQ - Linguagem Intermédia de Consulta Query
            // db.Veterinarios.ToListAsync() <=> SELECT * FROM veterenarios;
            // SELECT * FROM veterenarios;
            //return View(await db.TipoProduto.ToListAsync());
            return View(db.TipoProduto.ToListAsync());

        }


        // GET: Produtos/Details/5
        /// <summary>
        /// Mostra os detalhes de um produto, usando Lazy Loading
        /// </summary>
        /// <param name="id">vlor da PK do produto. admite um valor NULL, por causa do sinal ? </param>
        /// <returns></returns>

        //public async Task<IActionResult> Details(int? id)
        public IActionResult Details(int? id)

        {
            if (id == null)
            {
                // se o ID é NULL, é porque o meu utilizador está a testar a minha aplicação!!!
                // redirecciona para o método INDEX deste mesmo controller!!!
                return RedirectToAction("Index");

                //return NotFound();

            }

            //var tipoProduto = await db.TipoProduto
            //    .FirstOrDefaultAsync(m => m.ID == id);

            // esta expressão db.Veterinarios.FirstOrDefaultAsync(m => m.ID == id
            // é uma forma diferente de escrever o seguinte comando:
            // SELECT * FROM veterinarios v WHERE v.ID =id     v ---> letra para a tabela veterinarios
            // esta expressão é escrita em LINQ

            var tipoProduto = db.TipoProduto
                .FirstOrDefault(m => m.ID == id); // v--->são os registos numa linha da tabela dos veterinarios


            if (tipoProduto == null)
            {
                // se o ID é NULL, é porque o meu utilizador está a testar a minha aplicação!!!
                // ele introduziu um numero que nao existe
                // redirecciona para o método INDEX deste mesmo controller!!!
                return RedirectToAction("Index");
                //return NotFound();
            }

            return View(tipoProduto);
        }

        //--------------------------------------------------------------------------------07/07/2020

        // GET: produtos/Details2/5
        /// <summary>
        /// Mostra os detalhes de um veterinário, usando Eager Loading (método do "ancioso")
        /// </summary>
        /// <param name="id">vlor da PK do veterinário. admite um valor NULL, por causa do sinal ? </param>
        /// <returns></returns>
        public IActionResult Details2(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            // esta expressão db.Veterinarios.FirstOrDefaultAsync(m => m.ID == id
            // é uma forma diferente de escrever o seguinte comando:
            /// SELECT * 
            /// FROM db.veterinarios v, db.Consultas c, dbAnimais a, db.Donos d
            /// WHERE c.VeterinariosFK=v.ID AND
            ///       c.AnimalFK=a.ID AND
            ///       a.AnimalFK=d.ID AND
            ///       v.ID = id
            ///       
            // esta expressão é escrita em LINQ
            var produto = db.Produto
                                .Include(c => c.Compra)
                                .ThenInclude(cli => cli.Cliente)
                                .FirstOrDefault(c => c.ID == id);

            if (produto == null)
            {
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        //---------------------------------------------------------------------------------Inicio 12/7/2020

        // GET: Produtos/Create
        /// <summary>
        /// Invocar a View de criação de um nvo Produto
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Concretização da escrita de um novo Produto
        /// </summary>
        /// <param name="tipoProduto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Descricao,NumSerie,Marca,Modelo,Preco,IVA,")] TipoProduto TipoProduto, IFormFile fotoProd)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Add(tipoProduto);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(tipoProduto);


            //**************************************
            // processar a imagem
            //**************************************
            // vars. auxiliares
            bool haFicheiro = false;
            string caminhoCompleto = "";
            // será que há imagem?
            if (fotoProd == null)
            {
                // o utilizador não fez upload de um ficheiro
                TipoProduto.Foto = "avatar.jpg";
            }
            else
            {
                // existe fotografia
                // Mas, será boa?
                if (fotoProd.ContentType == "image/jpeg" ||
                    fotoProd.ContentType == "image/png")
                {
                    // estamos perante uma boa foto
                    // temos de gerar um nome para o ficheiro
                    Guid g;
                    g = Guid.NewGuid();
                    // obter a extensão do ficheiro
                    string extensao = Path.GetExtension(fotoProd.FileName);//.ToLower();
                    string nomeFicheiro = g.ToString() + extensao;
                    //onde guardar o ficheiro
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "imagens\\vets", nomeFicheiro);
                    // atribuir o nome do ficheiro ao Veterinário
                    TipoProduto.Foto = nomeFicheiro;
                    // marcar q existe uma fotografia
                    haFicheiro = true;

                }
                else
                {
                    // o ficheiro não é válido
                    TipoProduto.Foto = "avatar.png";
                }

            }

            try
            {
                if (ModelState.IsValid)
                {
                    // adicionar o novo veterinário à DB, mas na memória do servidor APS .NET
                    db.Add(TipoProduto);
                    // consolido os dados no servidor BD (está a fazer uma especie de COMMIT)
                    db.SaveChanges();
                    // será que há foto para gravar?
                    if (haFicheiro)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        fotoProd.CopyTo(stream);
                    }


                    // redireciona a ação para a View do Index
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {

                throw;
            }
            // Quando ocorre um erro, reenvio os dados do veterinario para a View da criação
            return View(TipoProduto);

        }
        //-------------------------------------------------------------------------------------Fim 12/7/2020



        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await db.TipoProduto.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View(tipoProduto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] TipoProduto tipoProduto)
        {
            if (id != tipoProduto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                        db.Update(tipoProduto);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoExists(tipoProduto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProduto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await db.TipoProduto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProduto = await db.TipoProduto.FindAsync(id);
            db.TipoProduto.Remove(tipoProduto);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdutoExists(int id)
        {
            return db.TipoProduto.Any(e => e.ID == id);
        }
    }
}

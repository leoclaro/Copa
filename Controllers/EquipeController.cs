using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace copa.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class EquipeController : ControllerBase
    {
        List<Equipe> equipes;
        public EquipeController()
        {
            this.equipes = JsonSerializer.Deserialize<List<Equipe>>(new WebClient().DownloadString("https://raw.githubusercontent.com/delsonvictor/testetecnico/master/equipes.json"));
        }

        [HttpGet]
        public IEnumerable<Equipe> Get()
        {
            return this.equipes;
        }

        [HttpPost]
        [Route("resultado")]
        public ActionResult<Resultado> GetResultado([FromBody] List<Equipe> equipes)
        {
            // ordenando equipes
            var equipesOrdenadas = (List<Equipe>)equipes.OrderBy(e => FormatEquipeNome(e.nome)).ToList();

            // equipes
            var equipe1 = GetEquipeFullObjectById(equipesOrdenadas[0]);
            var equipe2 = GetEquipeFullObjectById(equipesOrdenadas[1]);
            var equipe3 = GetEquipeFullObjectById(equipesOrdenadas[2]);
            var equipe4 = GetEquipeFullObjectById(equipesOrdenadas[3]);
            var equipe5 = GetEquipeFullObjectById(equipesOrdenadas[4]);
            var equipe6 = GetEquipeFullObjectById(equipesOrdenadas[5]);
            var equipe7 = GetEquipeFullObjectById(equipesOrdenadas[6]);
            var equipe8 = GetEquipeFullObjectById(equipesOrdenadas[7]);

            // quartas de final
            var quartasFinalChave1 = new List<Equipe>();
            quartasFinalChave1.Add(equipe1);
            quartasFinalChave1.Add(equipe8);

            var quartasFinalChave2 = new List<Equipe>();
            quartasFinalChave2.Add(equipe2);
            quartasFinalChave2.Add(equipe7);

            var quartasFinalChave3 = new List<Equipe>();
            quartasFinalChave3.Add(equipe3);
            quartasFinalChave3.Add(equipe6);

            var quartasFinalChave4 = new List<Equipe>();
            quartasFinalChave4.Add(equipe4);
            quartasFinalChave4.Add(equipe5);

            // semifinais
            var semifinaisChave1 = new List<Equipe>();
            semifinaisChave1.Add(this.CalcularResultado(quartasFinalChave1));
            semifinaisChave1.Add(this.CalcularResultado(quartasFinalChave2));

            var semifinaisChave2 = new List<Equipe>();
            semifinaisChave2.Add(this.CalcularResultado(quartasFinalChave3));
            semifinaisChave2.Add(this.CalcularResultado(quartasFinalChave4));

            // final
            var finalChave = new List<Equipe>();
            finalChave.Add(this.CalcularResultado(semifinaisChave1));
            finalChave.Add(this.CalcularResultado(semifinaisChave2));

            Quartasfinal quartasfinal = new Quartasfinal();
            quartasfinal.chave1 = this.GetChaveTextFormat(equipe1, equipe8, this.CalcularResultado(quartasFinalChave1));
            quartasfinal.chave2 = this.GetChaveTextFormat(equipe2, equipe7, this.CalcularResultado(quartasFinalChave2));
            quartasfinal.chave3 = this.GetChaveTextFormat(equipe3, equipe6, this.CalcularResultado(quartasFinalChave3));
            quartasfinal.chave4 = this.GetChaveTextFormat(equipe4, equipe5, this.CalcularResultado(quartasFinalChave4));

            Semifinais semifinais = new Semifinais();
            semifinais.chave1 = this.GetChaveTextFormat(this.CalcularResultado(quartasFinalChave1), this.CalcularResultado(quartasFinalChave2), this.CalcularResultado(semifinaisChave1));
            semifinais.chave2 = this.GetChaveTextFormat(this.CalcularResultado(quartasFinalChave3), this.CalcularResultado(quartasFinalChave4), this.CalcularResultado(semifinaisChave2));

            Resultado resultado = new Resultado();
            resultado.campeao = this.CalcularResultado(finalChave).nome;
            resultado.vice = this.CalcularResultado(finalChave, false).nome;
            resultado.final = this.GetChaveTextFormat(this.CalcularResultado(semifinaisChave1), this.CalcularResultado(semifinaisChave2), this.CalcularResultado(finalChave));
            resultado.quartasfinal = quartasfinal;
            resultado.semifinais = semifinais;

            return resultado;
        }

        private string FormatEquipeNome(string nome)
        {
            return Regex.Match(nome, @"\d+").Value.PadLeft(2,'0');
        }

        private Equipe GetEquipeFullObjectById(Equipe equipe)
        {
            return (Equipe) this.equipes.First(e => e.id.Contains(equipe.id));
        }

        private string GetChaveTextFormat(Equipe equipe1, Equipe equipe2, Equipe equipeVencedora)
        {            
            return string.Format("{0} {1} x {2} {3}", ((equipeVencedora.id == equipe1.id) ? "(equipe vencedora) " : ""), equipe1.nome, equipe2.nome, ((equipeVencedora.id.Contains(equipe2.id)) ? " (equipe vencedora)" : ""));
        }
        private Equipe CalcularResultado(List<Equipe> equipes, Boolean vencedor = true)
        {            
            if (equipes[0].gols > equipes[1].gols)
                return (vencedor) ? equipes[0] : equipes[1];
            else if (equipes[0].gols < equipes[1].gols)
                return (vencedor) ? equipes[1] : equipes[0];
            else
                return (vencedor) ? equipes.OrderBy(e => FormatEquipeNome(e.nome)).First() : equipes.OrderBy(e => FormatEquipeNome(e.nome)).Last();                 
        }
    }
}


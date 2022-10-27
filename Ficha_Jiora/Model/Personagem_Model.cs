using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_Jiora.Model
{
    internal class Personagem_Model
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string NomeEstigma { get; set; }
        public int Nivel { get; set; }
        public string Imagem { get; set; }
        public string EstigmaImagem { get; set; }
        public string Classe { get; set; }
        public string Raca { get; set; }
        public int PontosPericia { get; set; }
        public int Tonz { get; set; }
        public string Cabelo { get; set; }
        public string Olhos { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string Nascimento { get; set; }
        public int EXPAtual { get; set; }
        public bool Ativo { get; set; }
        public int Iniciativa { get; set; }
        public string Sexo { get; set; }
        public string Idade { get; set; }
        public int Turnos { get; set; }
        public string TextoMestre { get; set; }
        public string Anotacoes { get; set; }
        public int Forca { get; set; }
        public int Vitalidade { get; set; }
        public int Velocidade { get; set; }
        public int Foco { get; set; }
        public int Magia { get; set; }
        public int Aura { get; set; }
        public int ModForca { get; set; }
        public int ModVitalidade { get; set; }
        public int ModVelocidade { get; set; }
        public int ModFoco { get; set; }
        public int ModMagia { get; set; }
        public int ModAura { get; set; }
        public int Defesa { get; set; }
        public int Potencia { get; set; }
        public int Resistencia { get; set; }
        public int ModDefesa { get; set; }
        public int ModResistenca { get; set; }
        public int CDS_Critico { get; set; }
        public double Valor_Critico { get; set; }
        public int Mod_CDSCritico { get; set; }
        public double Mod_ValorCritico { get; set; }
        public int Especial { get; set; }
        public int HPMax { get; set; }
        public int HPAtual { get; set; }
        public int MPMax { get; set; }
        public int MPAtual { get; set; }
        public int PontosEstigma { get; set; }
        public int Res_Water { get; set; }
        public int Res_Fire { get; set; }
        public int Res_Earth { get; set; }
        public int Res_Wind { get; set; }
        public int Res_Thunder { get; set; }
        public int Res_Ice { get; set; }
        public int Res_Light { get; set; }
        public int Res_Shadow { get; set; }
        public int Mod_Res_Fire { get; set; }
        public int Mod_Res_Water { get; set; }
        public int Mod_Res_Wind { get; set; }
        public int Mod_Res_Thunder { get; set; }
        public int Mod_Res_Earth { get; set; }
        public int Mod_Res_Ice { get; set; }
        public int Mod_Res_Light { get; set; }
        public int Mod_Res_Shadow { get; set; }
        public int Res_Burn { get; set; }
        public int Res_Fronze { get; set; }
        public int Res_Poison { get; set; }
        public int Res_Confuse { get; set; }
        public int Res_Paralyze { get; set; }
        public int Res_Silence { get; set; }
        public int Res_Blind { get; set; }
        public int Res_Charm { get; set; }
        public bool Charm_Ativo { get; set; }
        public bool Paralyze_Ativo { get; set; }
        public bool Blind_Ativo { get; set; }
        public bool Frozen_Ativo { get; set; }
        public bool Burn_Ativo { get; set; }
        public bool Poison_Ativo { get; set; }
        public bool Silence_Ativo { get; set; }
        public bool Confuse_Ativo { get; set; }
        public int Mod_Esquiva { get; set; }
        public int Mod_Precisao { get; set; }

    }
}

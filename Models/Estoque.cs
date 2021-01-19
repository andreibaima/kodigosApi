using System;

namespace kodigos.api.Models
{

    
    public class Estoque {
  
        public Estoque() {
            id = Guid.NewGuid();
            // id_prod = prod.id;
        }

        // public Produto prod { get; }

        public Guid id { get;}

        public int id_prod { get; set;}

        public int qtd { get; set; }
    }
}
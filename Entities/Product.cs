
namespace ExerFixacaoTrabalhandoComArquivos.Entities
{
    class Product
    {
        public string NameProduct { get; set; }
        public double PriceProduct { get; set; }
        public int QuantityProduct { get; set; }

        public Product(string nameProduct, double priceProduct, int quantityProduct)
        {
            NameProduct = nameProduct;
            PriceProduct = priceProduct;
            QuantityProduct = quantityProduct;
        }
        public double PriceTotal()
        {
            return PriceProduct * QuantityProduct;
        }
    }
}

namespace Entity
{
    public class Transaction
    {
        public int Tx_ID { get; set; }
        public string AccountNo { get; set; }
        public string Date { get; set; }
        public double Balance { get; set; }
        public double Deposit { get; set; }
        public double Withdraw { get; set; }
    }
}

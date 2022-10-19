using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Account
    {
        #region Data Members
        private int accountNumber;
        private string customerNumber;
        private DateTime dateOpened; 
        private DateTime dateClosed;
        private bool isOpen;
        private double balance;
        private double availableCredit;
        #endregion

        #region Constrctors
        public Account()
        {
            isOpen = true;
        }
        public Account(int accNo, String custNo, DateTime opened, DateTime closed, bool isOpen, double credit, double balanace)
        {
            accountNumber = accNo;
            customerNumber = custNo;
            dateOpened = opened;
            dateClosed = closed;
            this.isOpen = isOpen;
            this.balance = balanace;
            availableCredit = credit;
    }
        #endregion

        #region Property methods
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public DateTime DateOpened
        {
            get { return dateOpened; }
            set { dateOpened = value; }
        }
        public DateTime DateClosed
        {
            get { return dateClosed; }
            set { dateClosed = value; }
        }
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }
        public double AvailableCredit
        {
            get { return availableCredit; }
            set { availableCredit = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            if (isOpen)
                return "Open: " + DateOpened.ToString();
            else
                return "Closed: " + DateClosed.ToString();
        }
        #endregion
    }
}

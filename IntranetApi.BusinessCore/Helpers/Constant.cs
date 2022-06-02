using System;
namespace IntranetApi.BusinessCore.Helpers
{
	public class Constant
	{
		public const string CheckBookRequestQuery = "SELECT a.ac_desc account_name," +
    " a.cust_ac_no account_number, " +
    "b.order_date order_date,a.branch_code domiciled_branch, " +
    "(SELECT branch_name FROM fcubsuser.sttm_branch WHERE branch_code = a.branch_code)" +
    " domiciled_branch_name, " +
    "(SELECT BRANCH_ADDR1 FROM fcubsuser.sttm_branch WHERE branch_code = a.branch_code)" +
    "domiciled_branch_address, b.check_leaves no_of_leaves, b.branch delivery_branch, " +
    "(SELECT branch_name FROM fcubsuser.sttm_branch WHERE branch_code = b.branch) " +
    "delivery_branch_name, (SELECT BRANCH_ADDR1 FROM fcubsuser.sttm_branch WHERE branch_code = b.branch) " +
    "delivery_branch_address, c.routing_no sort_code, a.ccy currency, b.first_check_no range_start," +
    "(b.first_check_no + b.check_leaves - 1) range_end, " +
    "DECODE (d.customer_type, 'I', '01', 'C', '02', 'B', '03')" +
    "Check_Type, a.account_class Scheme_code " +
    "FROM fcubsuser.sttm_cust_account a, " +
    "fcubsuser.catm_check_book b, fcubsuser.sttm_branch c, fcubsuser.sttm_customer d " +
    "WHERE a.cust_ac_no = b.account " +
    "AND a.branch_code = c.branch_code " +
    "AND a.cust_no = d.customer_no " +
    "AND b.REQUEST_STATUS = 'Requested'" +
    "AND b.order_date between :STARTDATE and :ENDDATE";

	}
}





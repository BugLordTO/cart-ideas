
//3rd
public interface Employee
{
    void EmployeeRequest (string mobile,string bizId);
    List<EmployeeRequest> GetEmployeeRequest(string bizId);
    List<Employee> GetEmployee(string bizId);
}

//Mana
public interface Employee
{
    EmployeeContract GetEmployeeRequest (string employeeContractId);
    ///รับจาก submitFrom  เสร็จแล้ว  hookไปบอก  3rd ด้วย    
    ClientResponse EmployeeConsent (string employeeContractId,bool IsAgree);
}

class EmployeeRequest
{
    public string Id { get; set; }     
    public string Code { get; set; }
    public string Mobile { get; set; }
    public string BizId { get; set; }
    public List<Title> Title { get; set; }
    // Agree, Pending,Reject
    public string Status { get; set; }
    public DateTime? ConsentDate { get; set; }
    public DateTime CreateDate { get; set; } 
}

class Employee
{
    public string _id { get; set; }   
    public string PAId { get; set; }  
    public string BizId { get; set; }
    public DateTime SignDate { get; set; } 
    public DateTime? ResignDate { get; set; } 
    public DateTime? SuspendDate { get; set; } 
    
}

class EmployeeService
{
    public string _id { get; set; }   
    public string EmployeeId { get; set; }  
    public string ServiceId { get; set; }
    public List<Title> Title { get; set; } // ตำแหน่ง
    public DateTime CreateDate { get; set; } 
    public DateTime? SuspendDate { get; set; }
}

class Title
{
    public string Code { get; set; }
    public string Name { get; set; }
}
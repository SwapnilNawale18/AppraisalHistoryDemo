﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalHistoryApiDemo;
using System.Text.RegularExpressions;

namespace AppraisalHistoryDemo
{
    class Validation
    {
        public static bool isValidContact(string inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputMobileNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
            if (re.IsMatch(inputEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, gender, email, contactNo, address;
            int departmentid;
            string jobRoleName;
            int option, subOption;
            string oldRole, newRole;
            int employeeID;
            string mainOption;
            string newEmail;
            int performance;
            bool check;
            AppraisalHistoryCrud.CreateConnection();
            Console.WriteLine();
            do
            {
                Console.WriteLine("---------------T-Company Appraisal History---------------");
                Console.WriteLine("1. View/Add/Modify information of Employee");
                Console.WriteLine("2. View varoius reports of Employee");
                Console.WriteLine("3. View/Add/Modify information of Job Roles");
                Console.Write("Enter your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                

                if(option==1)
                {
                    Console.WriteLine("1. Display Personal Details of Employee");
                    Console.WriteLine("2. Display Performance Details of Employee");
                    Console.WriteLine("3. Add new employee");
                    Console.WriteLine("4. New appraisal of an employee");
                    Console.WriteLine("5. Promote employee based on performance");
                    Console.WriteLine("6. Promote best performer to next to next higher role");
                    Console.WriteLine("7. Update employee email");
                    Console.WriteLine("8. Increase Performance of an Employee");
                    Console.Write("Enter your choice again: ");
                    subOption = Convert.ToInt32(Console.ReadLine());
                    switch (subOption)
                    {
                        case 1:
                            AppraisalHistoryCrud.DisplayData();
                        break;
                        case 2:
                            AppraisalHistoryCrud.DisplayPerformanceDetails();
                            break;
                        case 3:
                            Console.Write("Enter First Name: ");
                            firstName = Console.ReadLine();
                            while (string.IsNullOrEmpty(firstName))
                            {
                                Console.WriteLine("Please enter your first name");
                                Console.Write("Enter First Name again: ");
                                firstName = Console.ReadLine();
                            }
                            Console.Write("Enter Last Name: ");
                            lastName = Console.ReadLine();
                            while (string.IsNullOrEmpty(lastName))
                            {
                                Console.WriteLine("Please enter your last name");
                                Console.Write("Enter Last Name again: ");
                                lastName = Console.ReadLine();
                            }
                            Console.Write("Enter Gender: ");
                            gender = Console.ReadLine().ToUpper();
                            while (string.IsNullOrEmpty(gender))
                            {
                                Console.WriteLine("Please enter Male/Female or Other");
                                Console.Write("Enter Gender again: ");
                                gender = Console.ReadLine();
                            }
                            while (true)
                            {
                                Console.Write("Enter Email: ");
                                email = Console.ReadLine();
                                check = Validation.isValidEmail(email);
                                if (check == true)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter correct email");
                                    continue;
                                }
                            }
                            while(true)
                            {
                                Console.Write("Enter Contact: ");
                                contactNo = Console.ReadLine();
                                check = Validation.isValidContact(contactNo);
                                if (check == true)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Length of Phone number must be 10");
                                    continue;
                                }
                            }
                            Console.Write("Enter Address: ");
                            address = Console.ReadLine();
                            while (string.IsNullOrEmpty(address))
                            {
                                Console.WriteLine("Address cannot be empty");
                                Console.Write("Enter address again: ");
                                address = Console.ReadLine();
                            }
                            Console.Write("Enter Department ID: ");
                            departmentid = Convert.ToInt32(Console.ReadLine());
                            while (string.IsNullOrEmpty(departmentid.ToString()))
                            {
                                Console.WriteLine("Department ID cannot be empty");
                                Console.Write("Enter Department ID again: ");
                                departmentid = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine("List of Job Roles");
                            AppraisalHistoryCrud.DisplayJobRoles();
                            Console.Write("Enter Job Role Name: ");
                            jobRoleName = Console.ReadLine();
                            while (string.IsNullOrEmpty(jobRoleName))
                            {
                                Console.WriteLine("Job role cannot be empty");
                                Console.Write("Enter job role name again: ");
                                jobRoleName = Console.ReadLine();
                            }
                            AppraisalHistoryCrud.InsertNewEmployee(firstName, lastName, gender, email, contactNo, address, departmentid, jobRoleName);
                            break;
                        case 4:
                            Console.Write("Enter employee ID for Appraisal");
                            employeeID = Convert.ToInt32(Console.ReadLine());
                            AppraisalHistoryCrud.DisplayJobRoles();
                            Console.Write("Enter Job Role Name for Appraisal");
                            newRole = Console.ReadLine();
                            AppraisalHistoryCrud.Appraisal(employeeID, newRole);
                            break;
                        case 5:
                            Console.WriteLine("List of employees eligible for appraisal based on performance");
                            AppraisalHistoryCrud.EligibleForAppraisal();
                            Console.Write("Enter employee ID for Appraisal: ");
                            employeeID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Job Role Name for Appraisal: ");
                            newRole = Console.ReadLine();
                            AppraisalHistoryCrud.Appraisal(employeeID, newRole);
                            break;
                        case 6:
                            Console.WriteLine("Best Perfromer");
                            AppraisalHistoryCrud.UpgradeRoleTwice();
                            Console.WriteLine("Upgraded Post to next to next post");
                            break;
                        case 7:
                            Console.Write("Enter employee ID for updating email: ");
                            employeeID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter New Email ID");
                            newEmail = Console.ReadLine();
                            AppraisalHistoryCrud.UpdateData(employeeID, newEmail);
                            break;
                        case 8:
                            Console.Write("Enter employee ID for increasing perofrmance: ");
                            employeeID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Enter performance perofrmance score: ");
                            performance = Convert.ToInt32(Console.ReadLine());
                            AppraisalHistoryCrud.IncreasePerformance(employeeID, performance);
                            break;
                        default:
                            Console.WriteLine("Error! Enter correct option");
                            break;
                    }
                }
                
                else if(option == 2)
                {
                    Console.WriteLine("1. Display list of employees who joined as a intern and now are managers");
                    Console.WriteLine("2. Display list of employees with maximum appraisals");
                    Console.WriteLine("3. Display list of employees whose role was not changed after appraisal");
                    Console.WriteLine("4. Display list of employees who did not have appraisal");
                    Console.Write("Enter your choice again: ");
                    subOption = Convert.ToInt32(Console.ReadLine());
                    switch (subOption)
                    {
                        case 1:
                            Console.WriteLine("Employees who joined as a intern and now are managers");
                            AppraisalHistoryCrud.JoinedAsNowManager();
                            break;
                        case 2:
                            Console.WriteLine("Employees with maximum appraisals");
                            AppraisalHistoryCrud.MaxAppraisal();
                            break;
                        case 3:
                            Console.WriteLine("Employees whose role was not changed after appraisal");
                            AppraisalHistoryCrud.NotChangedAftAppraisal();
                            break;
                        case 4:
                            Console.WriteLine("Employees who did not have appraisal");
                            AppraisalHistoryCrud.NotHadAppraisal();
                            break;
                        default:
                            Console.WriteLine("Error! Enter correct option");
                            break;
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("1. Display All Job Roles");
                    Console.WriteLine("2. Add New Job Role");
                    Console.WriteLine("3. Modify Job Role");
                    Console.WriteLine("4. Delete Job Role");
                    Console.Write("Enter your choice again: ");
                    subOption = Convert.ToInt32(Console.ReadLine());
                    switch (subOption)
                    {
                        case 1:
                            Console.WriteLine("List of all job roles");
                            AppraisalHistoryCrud.DisplayJobRoles();
                            break;
                        case 2:
                            Console.Write("Enter name of new role you wish to add: ");
                            jobRoleName = Console.ReadLine();
                            while (string.IsNullOrEmpty(jobRoleName))
                            {
                                Console.WriteLine("Name of new role name cannot be empty");
                                Console.Write("Enter new role name address again: ");
                                jobRoleName = Console.ReadLine();
                            }
                            AppraisalHistoryCrud.AddRole(jobRoleName);
                            break;
                        case 3:
                            Console.Write("Enter name of role you whish to modify: ");
                            oldRole = Console.ReadLine();
                            while (string.IsNullOrEmpty(oldRole))
                            {
                                Console.WriteLine("Old role role name you wish to modify cannot be empty");
                                Console.Write("Enter old role name again: ");
                                oldRole = Console.ReadLine();
                            }
                            Console.Write("Enter new role name: ");
                            newRole = Console.ReadLine();
                            while (string.IsNullOrEmpty(newRole))
                            {
                                Console.WriteLine("New role name you wish to modify cannot be empty");
                                Console.Write("Enter New role name again: ");
                                newRole = Console.ReadLine();
                            }
                            AppraisalHistoryCrud.ModifyRole(oldRole, newRole);
                            break;
                        case 4:
                            Console.Write("Enter name of role you wish to delete: ");
                            jobRoleName = Console.ReadLine();
                            while (string.IsNullOrEmpty(jobRoleName))
                            {
                                Console.WriteLine("Role name which yo whish to delete cannot be empty");
                                Console.Write("Enter name of role you wish to delete again: ");
                                jobRoleName = Console.ReadLine();
                            }
                            AppraisalHistoryCrud.DeleteRole(jobRoleName);
                            break;
                        default:
                            Console.WriteLine("Error! Enter correct option");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Enter correct option");
                }
                Console.Write("Enter yes/y to contnue: ");
                mainOption=Console.ReadLine().ToLower();
            } while(mainOption=="yes" || mainOption == "y");
            Console.ReadKey();
        }
    }
}

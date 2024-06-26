﻿using AutoMapper;
using EmployeesLog.API.CustomActionFilters;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using EmployeesLog.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //blocking controller access from unAuthrized users.
   // [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }
        //Create
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateRequestEmployeeDto createEmployeeDto)
        {
            //DTO ==> DOMAIN.
            var employeeDomainModel = mapper.Map<Employee>(createEmployeeDto);

            //DOMAIN ==> DB
            employeeDomainModel = await employeeRepository.CreateAsync(employeeDomainModel);

            
            //DOMAIN ==> DTO ==> response.
            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));

        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> ReadAll()
        {
          var employees =  await employeeRepository.ReadAllAsync();

            if(employees is null)
            {
                return BadRequest();
            }

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            //from db to domainModle 
            var employeeDomainModel = await employeeRepository.ReadByIdAsync(id);
            
            if(employeeDomainModel == null)
            {
                return NotFound();
            }

            //from domain to dto.
            return Ok(employeeDomainModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        //[ValidateModel]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequestDto updateEmployeeRequestDto , [FromRoute]int id)
        {
            //dto ==> domain.
            var employeeDomainModel = mapper.Map<Employee>(updateEmployeeRequestDto);

            employeeDomainModel = await employeeRepository.UpdateByIdAsync(employeeDomainModel, id);

            if(employeeDomainModel is null)
            {
                return NotFound();
            }

            // from db ==> domain ==> dto.
            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel)); 

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            //db ==> domain.
            var employeeDomainModel = await employeeRepository.DeleteByIdAsync(id);

            if(employeeDomainModel is null)
            {
                return NotFound();
            }

            //domain ==> dto.
            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }
    }
}

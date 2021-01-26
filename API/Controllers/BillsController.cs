using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //TODO:
    //dovršiti metodu za update računa sa više stavaka
    public class BillsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BillsController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDto>>> GetBills()
        {
            var bills = await _context.Bills.Include(i => i.Items).ToListAsync();
            
            return Ok(_mapper.Map<IEnumerable<BillDto>>(bills));  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillDto>> GetBill(int id)
        {
            var bill = await _context.Bills.Include(i => i.Items).SingleOrDefaultAsync(b => b.id == id);

            return _mapper.Map<BillDto>(bill);
        }
            

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBill(int id)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.id == id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return Ok();
        }
       
        [HttpGet("userBills/{userId}")]
        public async Task<ActionResult> GetUserBill(int userId){
            //tu još razmislit jel treba iz sessiona id
           var user = await _context.Users.Include(u => u.Bills).ThenInclude(b => b.Items)
           .FirstOrDefaultAsync(u => u.id == userId);
           
           return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult> PostBills([FromBody] AppBill bill)
        {
            int userId = 1;
            var user = await _context.Users.FindAsync(userId);
            bill.AppUserid  = user.id;
            var billToSend = _mapper.Map<AppBill>(bill);
            await _context.Bills.AddAsync(billToSend);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> PutBills([FromBody] AppBill bill){
            // await Task.Run(() => {
            //     _context.Bills.Attach(bill);
            // }); 
            // _context.Entry(bill);
            var orgBill = await _context.Bills.FirstOrDefaultAsync(b => b.id == bill.id);
            _context.Entry(orgBill).CurrentValues.SetValues(bill);
            foreach (var item in bill.Items)
            {
                var orgItem = await _context.Items.FirstOrDefaultAsync(i => i.id == item.id);
                // ako već postoji stavka u računu mijenjaj joj vrijednosti
                if(orgItem != null){
                    _context.Entry(orgItem).CurrentValues.SetValues(item);
                }
                // ako ne postoji stavka u računu znači da je nova stavka..stavi je u račun
                else{
                    orgBill.Items.Add(new AppItem{
                        name = item.name, 
                        unitOfMeasure = item.unitOfMeasure,
                        nettoPrice = item.nettoPrice,
                        VAT = item.VAT 
                    });
                }
            }
            // var provjera = orgBill.Items.Select(i => bill.Items.Where(b => b.id == i.id));
            // var result = orgBill.Items.Where(p => !bill.Items.Any(p2 => p2.id == p.id));
            // foreach (var r in result)
            // {
            //    _context.Entry(r).State = EntityState.Deleted;
            // }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
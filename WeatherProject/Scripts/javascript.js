jQuery(document).ready(function() { 
var offset = 100; 
var duration = 10;		
jQuery(window).scroll(function() {	 
if (jQuery(this).scrollTop() > offset) { 
    jQuery('.back-to-top').fadeIn(duration); 
}
else { 
 jQuery('.back-to-top').fadeOut(duration); 
 } 
  });		
jQuery('.back-to-top').click(function(event) { 
event.preventDefault(); 
jQuery('html, body').animate({scrollTop: 0}, duration); 
 return false; 
		    }) 
		}); 
  
 $(document).ready(function() {  
     $(window).scroll(function() {
         console.log($(window).scrollTop())
         if ($(window).scrollTop() > 20) {
             $('#nav_bar').addClass('navbar-fixed');	     
         }
         if ($(window).scrollTop() < 21) {
             $('#nav_bar').removeClass('navbar-fixed');
         }
     });
 }); 

      $(document).ready(function(){
          // Show hide popover
          $(".dropdown").click(function(){
              $(this).siblings().find('.dropdown-menu').slideUp(-300);
              $(this).find(".dropdown-menu").slideToggle(-300);
          });
      });
$(document).on("click", function(event){
    var $trigger = $(".dropdown");
    if($trigger !== event.target && !$trigger.has(event.target).length){
        $(".dropdown-menu").slideUp(-300);
    }            
});

function validate() {
    var name = document.getElementById("name").value;		
    var pass1 = document.getElementById("pass1").value;
    var pass2 = document.getElementById("pass2").value;
    var add1 = document.getElementById("add1").value;
    var add2 = document.getElementById("add2").value;
    var city = document.getElementById("city").value;
    var state = document.getElementById("state").value;
    var country = document.getElementById("country").value;
    var phone = document.getElementById("phone").value;
    var pin = document.getElementById("pin").value;
    if(name == "" || pass1=="" || pass2 == "" || add1=="" || add2 == "" || city=="" || state == "" || country=="" || phone=="" || pin=="" )
    {
        alert("All fields are mandatory")
		
    }
    else {
        window.location.href = "SignIn.html";
    }
}
	

function phonenumber(inputtxt)  
{  
    var phoneno = /^\d{10}$/;  
    var ph = document.getElementById("phone").value;;
    if(ph.match(phoneno))  
    {  
        return true;  
    }  
    else  
    {  
        alert("Not a valid Phone Number");  
        return false;  
    }  
}  
function pin (inputtxt)    
{  
    var pin = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;  
    var pin = document.getElementById("pin").value;;
    if(pin.match(pin))  
    {  
        return true;  
    }  
    else  
    {  
        alert("Please Match The format");  
        return false;  
    }  
}  
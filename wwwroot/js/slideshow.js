
//     var slideIndex = 1;
//     showSlides(slideIndex);

//     function plusSlides(n) {
//         showSlides(slideIndex += n);
//     }

//     function currentSlide(n) {
//         showSlides(slideIndex = n);
//     }

//     function showSlides(n) {
//         var i;
//         var slides = document.getElementsByClassName("mySlides");
//         var dots = document.getElementsByClassName("dot");
//         if (n > slides.length) { slideIndex = 1 }
//         if (n < 1) { slideIndex = slides.length }
//         for (i = 0; i < slides.length; i++) {
//             slides[i].style.display = "none";
//         }
//         for (i = 0; i < dots.length; i++) {
//             dots[i].className = dots[i].className.replace(" active", "");
//         }
//         slides[slideIndex - 1].style.display = "block";
//         dots[slideIndex - 1].className += " active";
//     }

//     return(
// <div>
//     <div class="mySlides fade">
//         <div class="numbertext">2 / 3</div>
//         <img src="http://www.thekitchenwhisperer.net/wp-content/uploads/2012/05/Sunrise-Breakfast-Taters1.jpg" style="width:100%"/>
//         <div class="text">Caption Two</div>
//     </div>


//     <div class="mySlides fade">
//         <div class="numbertext"> 3 / 4</div>
//         <img src="~/../../wwwroot/img/lobster.jpeg" style="width:100%" >
//         <div class="text">Caption Two</div>
//     </div>


//     <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
//     <a class="next" onclick="plusSlides(1)">&#10095;</a>
// </div>
// <br/>


//     <div style="text-align:center">
//         <span class="dot" onclick="currentSlide(1)"></span>
//         <span class="dot" onclick="currentSlide(2)"></span>
//         @* <span class="dot" onclick="currentSlide(3)"></span>
//         <span class="dot" onclick="currentSlide(4)"></span> *@
//     </div>
// </div>
// )

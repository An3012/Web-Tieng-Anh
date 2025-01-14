var sync1;
$(document).ready(function () {
    sync1 = $("#sync1");
    sync1.owlCarousel({
        items: 1,
        slideSpeed: 2000,
        nav: true,
        autoplay: true,
        dots: false,
        loop: false,
        responsiveRefreshRate: 200,
    })
    sync1.on('changed.owl.carousel', function (event) {
        var currentIndex = event.item.index;
        $('#navSlide .item').removeClass('active')
        $('#navSlide .item').eq(currentIndex).addClass('active');
    });

    $('#service').owlCarousel({
        items: 1,
        slideSpeed: 2000,
        nav: true,
        autoplay: true,
        dots: false,
        loop: false,
        responsiveRefreshRate: 200,
        navText: ['<svg width="100%" height="100%" viewBox="0 0 11 20"><path style="fill:none;stroke-width: 1px;stroke: #fff;" d="M9.554,1.001l-8.607,8.607l8.607,8.606"/></svg>', '<svg width="100%" height="100%" viewBox="0 0 11 20" version="1.1"><path style="fill:none;stroke-width: 1px;stroke: #fff;" d="M1.054,18.214l8.606,-8.606l-8.606,-8.607"/></svg>'],
    })
    $('#project_mobile').owlCarousel({
        items: 1.3,
        slideSpeed: 2000,
        nav: false,
        autoplay: true,
        dots: false,
        loop: false,
        responsiveRefreshRate: 200,
        margin: 16
        //navText: ['<svg width="100%" height="100%" viewBox="0 0 11 20"><path style="fill:none;stroke-width: 1px;stroke: #fff;" d="M9.554,1.001l-8.607,8.607l8.607,8.606"/></svg>', '<svg width="100%" height="100%" viewBox="0 0 11 20" version="1.1"><path style="fill:none;stroke-width: 1px;stroke: #fff;" d="M1.054,18.214l8.606,-8.606l-8.606,-8.607"/></svg>'],
    })
    $('#lsht_sync1').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true, // for smooth transitions
        asNavFor: '#lsht_sync2', // Links to the thumbnail slider
        infinite: true,
        autoplay: true
    });
    $('#lsht_sync2').slick({
        dots: false,
        infinite: false,
        vertical: true,
        draggable: false,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 1,
        focusOnSelect: true,
        centerMode: false,
        asNavFor: '#lsht_sync1',
        prevArrow: '<button type="button" class="slick-prev"><img src="./Image/vuesax/linear/arrow-up.png" class="w-8 h-8" /></button>',
        nextArrow: '<button type="button" class="slick-next"><img src="./Image/vuesax/linear/arrow-down.png" class="w-8 h-8" /></button>',
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 5,
                    slidesToScroll: 1,
                    infinite: false,
                    dots: false,
                    vertical: false,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 5,
                    slidesToScroll: 1,
                    vertical: false,
                    infinite: false,
                    dots: false,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    vertical: false,
                    infinite: false,
                    dots: false,
                }
            },
            {
                breakpoint: 320,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    vertical: false,
                    infinite: false,
                    dots: false,
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    $('#slide_gallery').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: true,
        fade: false,
        draggable: true,
        infinite: true,
        autoplay: true,
        vertical: false,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: false,
                    dots: false,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: false,
                    dots: false,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: false,
                    dots: false,
                }
            },
            {
                breakpoint: 320,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: false,
                    dots: false,
                }
            }
        ]
    });
    $('.slideTTNB').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        dots: true,
        fade: false,
        draggable: true,
        infinite: true,
        autoplay: true,
        vertical: false,
    });

    $('.primary-menu > li > a').click(function (e) {
        e.preventDefault(); // Ngăn chặn hành động mặc định của thẻ a
        var $submenu = $(this).next('.sub-menu');
        
        // Ẩn tất cả các menu con khác
        $('.sub-menu').not($submenu).slideUp();
        
        // Mở hoặc đóng menu con hiện tại
        $submenu.slideToggle();
    });

    $('.menu-mega-vertical > li').on('mouseover', function(e){
        console.log(e);
        const tabNum = $(this).data('tab');
        console.log(tabNum);

        if (tabNum) {
            $(this).parent().find('li').removeClass('active');
            $(this).addClass('active')
            $('.mega-menu .content-tab').addClass('hidden');
            $(`.mega-menu  #tab_${tabNum}`).removeClass('hidden');
        }
    })
})


function toggleFooterMenu(elm) {
    $(elm).parent().find('ul').toggleClass('hidden');
}

function goToSlide(elm, num) {
    $('#navSlide .item').removeClass('active')
    $(elm).addClass('active');
    sync1.data('owl.carousel').to(num - 1, 300, true);
}

function isValidPhone(phone) {
    const phonePattern = /^[0-9]{10,11}$/;
    return phonePattern.test(phone);
}

function isValidEmail(email) {
    const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
}

document.addEventListener("DOMContentLoaded", function () {

})

const toggleSeachForm = () => {
    $('#formSearch').toggleClass('-translate-y-16');
    $('#formSearch').toggleClass('translate-y-0');

}
const toggleNavMobile = () => {
    $('#navBackdrop').toggleClass('hidden');
    $('#navMobile').toggleClass('-translate-x-[280px]');
    $('#navMobile').toggleClass('translate-x-0');
}

function toggleModal() {
    document.getElementById('modal').classList.toggle('hidden')
}
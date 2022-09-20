function Inicio(){

	$('.sidebar-menu').tree();

	$(".treeview-menu a").click(function(e){
		e.preventDefault();
        url = $(this).attr("href");
        $.post( url, {url:url},function(data) {
        		if(url!="#")
        			$(".content-header" ).html(data);
        });
     });

}
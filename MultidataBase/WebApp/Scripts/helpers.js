function shuffle_b(bool){

    if(bool==false){
    $("#btn-include").addClass("hide");
    $("#spinner").removeClass("hide");
    }
    else {
        $("#spinner").addClass("hide");
        $("#btn-include").removeClass("hide");
    }
}
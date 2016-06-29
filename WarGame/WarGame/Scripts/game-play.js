var game_play = function () {

    var attack = function (id) {
        $.ajax({
            url: "/maps/attack/"+id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                /* ABRIR MODAL DE ATAQUE*/
            },
            error: function (data) {
                debugger;
                alert(data.message);
            }
        });
    };

    var battle = function (aid, did, atroops) {
        $.ajax({
            url: "maps/battle",
            type: "POST",
            dataType: "json",
            data: { aid: aid, did: did, atroops: atroops },
            success: function (data) {
                /* ABRIR MODAL COM OS RESULTADOS DA BATALHA */
                /* REMOVER TROPAS PERDIDAS */
            },
            error: function (data) {
                debugger;
                alert(data.message);
            }
        });
    };

    var distributed_troops = function (rid, pid) {
        $.ajax({
            url: "maps/"+rid+"/distribute-troops/"+pid,
            type: "GET",
            dataType: "json",
            success: function (data) {
                /* ABRIR MODAL DE DISTRIBUIÇÃO DE TROPAS */
            },
            error: function (data) {
                debugger;
            }
        });
    };

    var add_troops = function (rid, troops, text) {
        $.ajax({
            url: "maps/add-troops",
            type: "POST",
            dataType: "json",
            data: {rid: rid, troops: troops },
            success: function (data) {
                text.text = data.troops;
            },
            error: function (data) {
                debugger;
            }
        });
    };
    
    var move_troops = function (rid) {
        $.ajax({
            url: "maps/move-troops/"+{rid},
            type: "GET",
            dataType: "json",
            success: function (data) {
                /* ABRIR MODAL DE MOVER TROPAS */
            },
            error: function (data) {
                debugger;
            }
        });
    };

    var transfer_troops = function (sid, did, troops) {
        $.ajax({
            url: "maps/transfer-troops",
            type: "POST",
            dataType: "json",
            data: { sid: sid, did: did, troops: troops },
            success: function (data) {
                debugger;
            },
            error: function (data) {
                debugger;
            }
        });
    };


    return {
        attack: attack,
        distributed_troops: distributed_troops,
        add_troops: add_troops,
        move_troops: move_troops,
        transfer_troops: transfer_troops
    }

}();
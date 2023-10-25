using UnityEngine;
using UnityEngine.UI;

public class getranking : MonoBehaviour{
    private var RANKING_PREF_KEY = 'ranking';
    //ランキングの表示数
    private var RANKING_NUM = 10;
    //
    private var ranking = new float[RANKING_NUM];

    // ランキング取得
    function getRanking() {
        
        //Playerprefsからランキングを取得
        var ranking = PlayerPrefs.GetString(RANKING_PREF_KEY);

        if (ranking.length > 0) {
            var score = ranking.Split(',');
            ranking = new float[RANKING_NUM];
            for (var i=0; i<score.length && i<RANKING_NUM; i++) {
                ranking[i] = parseFloat(score[i]);
            }
        }
    }

    //保存
    function saveRanking(double new_score) {
        if (ranking) {
            var tmp = 0.0;
            //元データと比較
            for (var i=0; i<ranking.length; i++) {
                if (ranking[i] < new_score) {
                    tmp = ranking[i];
                    ranking[i] = new_score;
                    new_score = tmp;
                }
            }
        } else {
            ranking[0] = new_score;
        }
        //コンマで連結・playerprefsに保存
        var ranking_string = Array(ranking).join(',');
        PlayerPrefs.SetString(RANKING_PREF_KEY, ranking_string);
    }


    //ランキング削除
    function deleteRanking() {
        PlayerPrefs.DeleteKey(RANKING_PREF_KEY);
    }
}

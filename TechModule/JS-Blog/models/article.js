const Sequalize = require('sequelize');

module.exports = function (sequalize) {
    const Article = sequalize.define('Article',{
        title: {
          type : Sequalize.STRING,
            allowNull: false,
            required : true
        },
        content :{
          type : Sequalize.TEXT,
          allowNull: false,
          required: true
        },
        date : {
          type : Sequalize.DATE,
          required: true,
          allowNull: false,
          defaultValue: Sequalize.NOW,

        },
        });
    Article.associate = function (models) {
        Article.belongsTo(models.User,{
            foreignKey: 'authorID',
            targetKey : 'id'
        });
    };
    return Article;
};
﻿using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MovieDataService : IMovieDataService
    {
        public IMDBContext db = new IMDBContext();

        public movie_titles? GetMovieTitle(string id)
        {
            movie_titles? movie = db.movie_titles.Find(id);
            return movie;
        }


        //todo mangler generele funktioner der kigge i vores tabeler




        public List<BestMatchOut> best_match(List<string> input)
        {
            string ConcatInput = "select best_match('";
            foreach (string element in input)
            {
                if (input.Last().Equals(element))
                {
                    ConcatInput = ConcatInput + element;
                    ConcatInput = ConcatInput + "')";
                    break;
                }
                ConcatInput = ConcatInput + element;
                ConcatInput = ConcatInput + "', '";
            }

            var result = db.bestmatchouts.FromSqlInterpolated($"select best_match({ConcatInput})");
            return result.ToList();
        }

        
        //todo tjek om dette skal med i pogrammet
        /*public exact_match(string input)
        {

        }

        public exact_match(string userid string input)
        {

        }*/

        public List<MovieActorOut> find_coplayers(string nconst)
        {
            var result = db.movieactorout.FromSqlInterpolated($"select * find_coplayers({nconst})");
            return result.ToList();
        }

        public List<MovieActorOut> movie_actors_by_rating(string tconst)
        {
            var result = db.movieactorout.FromSqlInterpolated($"select * movie_actors_by_rating({tconst})");
            return result.ToList();
        }

        public void movie_visited(string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited({tconst})");
            db.SaveChanges();
        }

        public void name_rating_setter()
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited()");
            db.SaveChanges();
        }

        public List<MovieActorOut> similar_movies(string tconst)
        {
            var result = db.movieactorout.FromSqlInterpolated($"select * similar_movies({tconst})");
            return result.ToList();
        }

        public List<WordOut> word_word_match(string input)
        {
            var result = db.wordout.FromSqlInterpolated($"select * word_word_match({input})");
            return result.ToList();
        }
    }
    }

import Link from 'next/link';
import MovieActions from '../../../components/MovieActions';
import { Eye, EyeOff, Star, Calendar, User, Film } from 'lucide-react';

interface Movie {
  id: number;
  title: string;
  description: string;
  imageUrl: string;
  director: string;
  genre: string;
  releaseYear: number;
  rating: number;
  watched: boolean;
}

// Fetch all IDs for static export
export async function generateStaticParams() {
  const res = await fetch('http://localhost:5000/movies');
  const movies: Movie[] = await res.json();

  return movies.map((movie) => ({
    id: movie.id.toString(),
  }));
}

interface MoviePageProps {
  params: {
    id: string;
  };
}

// Server component
export default async function MoviePage({ params }: MoviePageProps) {
  const res = await fetch(`http://localhost:5000/movies/${params.id}`);
  const movie: Movie | null = await res.json();

  if (!movie) {
    return (
      <div className="container mx-auto px-4 py-16 text-center">
        <p className="text-red-600">Movie not found</p>
        <Link href="/" className="mt-4 inline-block px-4 py-2 bg-blue-600 text-white rounded-lg">
          Back to Movies
        </Link>
      </div>
    );
  }

  return (
    <div className="container mx-auto px-4 sm:px-6 lg:px-8">
      {/* Back Button */}
      <div className="mb-8">
        <Link
          href="/"
          className="inline-flex items-center px-4 py-2 text-gray-600 hover:text-gray-900 transition-colors"
        >
          Back to Movies
        </Link>
      </div>

      <div className="bg-white dark:bg-gray-800 rounded-xl shadow-lg overflow-hidden">
        <div className="md:flex">
          {/* Movie Poster */}
          <div className="md:w-1/3">
            <img
              src={movie.imageUrl}
              alt={movie.title}
              className="w-full h-96 md:h-full object-cover"
              onError={(e) => {
                (e.target as HTMLImageElement).src =
                  'https://via.placeholder.com/400x600/374151/9CA3AF?text=No+Image';
              }}
            />
          </div>

          {/* Movie Details */}
          <div className="md:w-2/3 p-8">
            <div className="flex justify-between items-start mb-6">
              <div>
                <h1 className="text-4xl font-bold mb-4">{movie.title}</h1>

                {/* Status Badge */}
                <div className="mb-4">
                  {movie.watched ? (
                    <span className="inline-flex items-center px-4 py-2 rounded-full text-sm font-medium bg-green-100 text-green-800">
                      <Eye className="w-4 h-4 mr-2" />
                      Watched
                    </span>
                  ) : (
                    <span className="inline-flex items-center px-4 py-2 rounded-full text-sm font-medium bg-yellow-100 text-yellow-800">
                      <EyeOff className="w-4 h-4 mr-2" />
                      To Watch
                    </span>
                  )}
                </div>
              </div>

              {/* Client Component for Actions */}
              <MovieActions movie={movie} />
            </div>

            {/* Movie Info Grid */}
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-6 mb-8">
              <div className="flex items-center space-x-3">
                <User className="w-5 h-5 text-gray-500" />
                <div>
                  <p className="text-sm text-gray-500">Director</p>
                  <p className="text-lg font-medium">{movie.director}</p>
                </div>
              </div>

              <div className="flex items-center space-x-3">
                <Film className="w-5 h-5 text-gray-500" />
                <div>
                  <p className="text-sm text-gray-500">Genre</p>
                  <p className="text-lg font-medium">{movie.genre}</p>
                </div>
              </div>

              <div className="flex items-center space-x-3">
                <Calendar className="w-5 h-5 text-gray-500" />
                <div>
                  <p className="text-sm text-gray-500">Release Year</p>
                  <p className="text-lg font-medium">{movie.releaseYear}</p>
                </div>
              </div>

              <div className="flex items-center space-x-3">
                <Star className="w-5 h-5 text-yellow-500" />
                <div>
                  <p className="text-sm text-gray-500">Rating</p>
                  <p className="text-lg font-medium">{movie.rating}/10</p>
                </div>
              </div>
            </div>

            {/* Description */}
            <div>
              <h3 className="text-xl font-semibold mb-4">Description</h3>
              <p className="text-gray-700 leading-relaxed text-lg">{movie.description}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
